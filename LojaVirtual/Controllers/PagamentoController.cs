﻿using LojaVirtual.Models.Cliente;
using LojaVirtual.Models.Pagamento;
using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using LojaVirtual.Repositories;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using Microsoft.AspNetCore.Mvc;
using System;
using PagarMe;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using LojaVirtual.Validations;
using Serilog;

namespace LojaVirtual.Controllers
{
    [Autorizacao.AcessoAutorizacao]
    public class PagamentoController : Controller
    {
        private readonly Sessao _sessao;
        private readonly IConfiguration _configuration;

        private readonly ClienteR _reposCliente;
        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;
        private readonly PedidoR _reposPedido;

        public PagamentoController(Sessao sessao, ClienteR reposCliente, ProdutoR reposProduto, CarrinhoR reposCarrinho, 
            PedidoR reposPedido, IConfiguration configuration)
        {
            _sessao = sessao;
            _configuration = configuration;

            _reposCliente = reposCliente;
            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
            _reposPedido = reposPedido;
        }

        //Operações
        [HttpPost]
        public IActionResult CalculaParcelas(float valor, float frete)
        {
            try
            {
                var total = new string[12];
                var parcelas = new string[12];

                var taxa = (valor * 3.79 / 100) + 1.2;
                valor += (float)taxa;

                total[0] = (valor + frete).ToString("C");

                for (var i = 2; i <= 12; i++)
                {
                    if (i <= 6)
                    {
                        taxa = (valor * 4.19 / 100) + 1.2;
                        valor += (float)taxa;

                        total[i -1] = (valor + frete).ToString("C");
                    }
                    else
                    {
                        taxa = (valor * 4.59 / 100) + 1.2;
                        valor += (float)taxa;

                        total[i -1] = (valor + frete).ToString("C");
                    }

                    parcelas[i -1] = (float.Parse(total[i -1].Replace("R$", "").Replace(".", "")) / i).ToString("C");
                }

                return Json(new[] { parcelas, total });
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Visualizar);
                return BadRequest(Global.Mensagem.FalhaCalculoParcelas);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PagamentoBoleto(EnderecoCliente endereco, Frete frete)
        {
            try
            {
                var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);
                var produtos = new List<Produto>();

                var total = 0.0F;

                foreach (var item in carrinho)
                {
                    var produto = _reposProduto.Buscar(item.IdProduto);
                    produtos.Add(produto);

                    total += produto.Valor * item.Quantidade;
                }

                total += frete.Valor;

                var transacao = PreparaTranscao(endereco, frete, produtos, carrinho);

                transacao.PaymentMethod = PaymentMethod.Boleto;
                transacao.Amount = Convert.ToInt32(total.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", ""));

                transacao.Save();

                if (transacao.Id != "0")
                {
                    var pedido = new Pedido
                    {
                        IdTransacao = Convert.ToUInt32(transacao.Id),
                        FormaPagamento = (byte)Global.Pagamento.Boleto,
                        Total = total,
                        DataCriacao = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Situacao = (byte)Global.Pedido.Aguardando,

                        Boleto = new Boleto
                        {
                            DataExpiracao = Convert.ToDateTime(transacao.BoletoExpirationDate),
                            Url = transacao.BoletoUrl,
                            CodigoBarras = transacao.BoletoBarcode
                        },

                        Endereco = new EnderecoPedido
                        {
                            Nome = endereco.Nome,
                            Cep = endereco.Cep,
                            Logradouro = endereco.Logradouro,
                            Numero = endereco.Numero,
                            Bairro = endereco.Bairro,
                            Cidade = endereco.Cidade,
                            Uf = endereco.Uf,
                            Complemento = endereco.Complemento ?? ""
                        }
                    };

                    pedido.Cliente = _reposCliente.Buscar(_sessao.UsuarioSessao().IdCliente);

                    pedido.Frete = frete;

                    pedido.Produto = new List<ProdutoHistorico>();

                    foreach (var item in produtos)
                    {
                        pedido.Produto.Add(new ProdutoHistorico
                        {
                            IdProduto = item.IdProduto,
                            IdUsuario = item.IdUsuario,
                            Nome = item.Nome,
                            Valor = item.Valor,
                            Situacao = (byte)Global.Produto.Aguardando,
                            CodRastreamento = "",
                            PrazoEntrega = Convert.ToDateTime("0001/01/01"),
                            DataAtualizacao = DateTime.Now,
                            Quantidade = carrinho.FirstOrDefault(c =>
                            c.IdProduto == item.IdProduto).Quantidade
                        });
                    }

                    _reposCarrinho.RemoverTodos(_sessao.UsuarioSessao().IdCliente);

                    if (_reposPedido.Registrar(pedido) > 0)
                    {
                        GerarLog((byte)Global.Entidade.Pedido, (byte)Global.Acao.Inserir, pedido.IdPedido);
                        return Json(Convert.ToInt32(transacao.Id));
                    }

                    return BadRequest($"{Global.Mensagem.FalhaPedido} {transacao.Id}");
                }

                return BadRequest(Global.Mensagem.FalhaTransacao);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Inserir);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PagamentoCartao(Cartao cartao, EnderecoCliente endereco, Frete frete, byte parcelas)
        {
            var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);
            var produtos = new List<Produto>();

            var total = 0.0F;

            foreach (var item in carrinho)
            {
                var produto = _reposProduto.Buscar(item.IdProduto);
                produtos.Add(produto);

                total += produto.Valor * item.Quantidade;
            }

            try
            {
                var transacao = PreparaTranscao(endereco, frete, produtos, carrinho);

                transacao.PaymentMethod = PaymentMethod.CreditCard;

                transacao.Card = new Card
                {
                    HolderName = cartao.Nome,
                    Number = cartao.Numero,
                    ExpirationDate = cartao.Vencimento.Replace("/", ""),
                    Cvv = cartao.Verificador
                };

                transacao.Card.Save();

                if (parcelas == 1)
                    total += (total * (float)3.79 / 100) + (float)1.2;

                else if (parcelas <= 6)
                    total += (total * (float)4.19 / 100) + (float)1.2;

                else
                    total += (total * (float)4.59 / 100) + (float)1.2;

                total += frete.Valor;

                transacao.Amount = Convert.ToInt32(total.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", ""));
                transacao.Installments = parcelas;

                transacao.Save();

                if (transacao.Id != "0")
                {
                    var pedido = new Pedido
                    {
                        IdTransacao = Convert.ToUInt32(transacao.Id),
                        FormaPagamento = (byte)Global.Pagamento.CartaoCredito,
                        Total = total,
                        DataCriacao = DateTime.Now,
                        DataAtualizacao = DateTime.Now,
                        Situacao = (byte)Global.Pedido.Processando,

                        Parcelamento = new Parcelamento
                        {
                            Parcelas = parcelas,
                            ValorParcela = total / parcelas,
                            ValorTotal = total,
                            Juros = false
                        },

                        Endereco = new EnderecoPedido
                        {
                            Nome = endereco.Nome,
                            Cep = endereco.Cep,
                            Logradouro = endereco.Logradouro,
                            Numero = endereco.Numero,
                            Bairro = endereco.Bairro,
                            Cidade = endereco.Cidade,
                            Uf = endereco.Uf,
                            Complemento = endereco.Complemento ?? ""
                        }
                    };

                    pedido.Cliente = _reposCliente.Buscar(_sessao.UsuarioSessao().IdCliente);

                    pedido.Frete = frete;

                    pedido.Produto = new List<ProdutoHistorico>();

                    foreach (var item in produtos)
                    {
                        pedido.Produto.Add(new ProdutoHistorico
                        {
                            IdProduto = item.IdProduto,
                            IdUsuario = item.IdUsuario,
                            Nome = item.Nome,
                            Valor = item.Valor,
                            Situacao = (byte)Global.Produto.Aguardando,
                            CodRastreamento = "",
                            PrazoEntrega = Convert.ToDateTime("0001/01/01"),
                            DataAtualizacao = DateTime.Now,
                            Quantidade = carrinho.FirstOrDefault(c =>
                            c.IdProduto == item.IdProduto).Quantidade
                        });
                    }

                    _reposCarrinho.RemoverTodos(_sessao.UsuarioSessao().IdCliente);

                    if (_reposPedido.Registrar(pedido) > 0)
                    {
                        GerarLog((byte)Global.Entidade.Pedido, (byte)Global.Acao.Inserir, pedido.IdPedido);
                        return Json(Convert.ToInt32(transacao.Id));
                    }

                    return BadRequest($"{Global.Mensagem.FalhaPedido} {transacao.Id}");
                }

                return BadRequest(Global.Mensagem.FalhaTransacao);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Pedido, (byte)Global.Acao.Inserir);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        public Transaction PreparaTranscao(EnderecoCliente endereco, Frete frete, List<Produto> produtos, List<Carrinho> carrinho)
        {
            PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");
            PagarMeService.DefaultEncryptionKey = _configuration.GetValue<string>("Pagamento:DefaultEncryptionKey");

            var cliente = _reposCliente.Buscar(_sessao.UsuarioSessao().IdCliente);

            var transacao = new Transaction
            {
                Customer = new Customer
                {
                    ExternalId = cliente.IdCliente.ToString(),
                    Name = cliente.Nome,
                    Type = CustomerType.Individual,
                    Country = "br",
                    Email = cliente.Email,

                    Documents = new[]
                    {
                        new Document {
                            Type = DocumentType.Cpf,
                            Number = cliente.Cpf
                        }
                    },

                    Birthday = cliente.Nascimento.ToString("yyyy-MM-dd")
                },

                Billing = new Billing
                {
                    Name = cliente.Nome,

                    Address = new Address
                    {
                        Country = "br",
                        State = cliente.Endereco.Uf,
                        City = cliente.Endereco.Cidade,
                        Neighborhood = cliente.Endereco.Bairro,
                        Street = cliente.Endereco.Logradouro,
                        StreetNumber = cliente.Endereco.Numero,
                        Zipcode = cliente.Endereco.Cep
                    }
                },

                Shipping = new Shipping
                {
                    Name = endereco.Nome,
                    Fee = Convert.ToInt32(frete.Valor.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", "")),
                    DeliveryDate = DateTime.Now.AddDays(frete.DiasEntrega).ToString("yyyy-MM-dd"),
                    Expedited = false,

                    Address = new Address
                    {
                        Country = "br",
                        State = endereco.Uf,
                        City = endereco.Cidade,
                        Neighborhood = endereco.Bairro,
                        Street = endereco.Logradouro,
                        StreetNumber = endereco.Numero,
                        Zipcode = endereco.Cep
                    }
                }
            };

            transacao.Item = new Item[produtos.Count];
            transacao.Customer.PhoneNumbers = new string[cliente.Contato.Count];

            var i = 0;

            foreach (var contato in cliente.Contato)
            {
                transacao.Customer.PhoneNumbers[i] = contato.Numero;
                i++;
            }

            i = 0;

            foreach (var produto in produtos)
            {
                var item = new Item
                {
                    Id = produto.IdProduto.ToString(),
                    Title = produto.Nome,
                    Quantity = (int)carrinho[i].Quantidade,
                    Tangible = true,
                    UnitPrice = Convert.ToInt32(produto.Valor.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", ""))
                };

                transacao.Item[i] = item;
                i++;
            }

            return transacao;
        }

        public void GerarLog(byte entidade, byte acao, uint objeto)
        {
            Log.ForContext("Usuario", Convert.ToString(_sessao.UsuarioSessao().IdUsuario))
                       .ForContext("Entidade", entidade).ForContext("Acao", acao).ForContext("Objeto", objeto).Information("");
        }

        public void GerarLogErro(Exception erro, byte entidade, byte acao)
        {
            Log.ForContext("Usuario", Convert.ToString(_sessao.UsuarioSessao().IdUsuario))
                       .ForContext("Entidade", entidade).ForContext("Acao", acao).Error(erro, "");
        }
    }
}