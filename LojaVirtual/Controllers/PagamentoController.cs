using LojaVirtual.Models.Cliente;
using LojaVirtual.Models.Pagamento;
using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using PagarMe;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace LojaVirtual.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly ClienteR _reposCliente;
        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;
        private readonly PedidoR _reposPedido;

        private readonly IConfiguration _configuration;

        public PagamentoController(ClienteR reposCliente, ProdutoR reposProduto, 
            CarrinhoR reposCarrinho, PedidoR reposPedido, IConfiguration configuration)
        {
            _reposCliente = reposCliente;
            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
            _reposPedido = reposPedido;

            _configuration = configuration;
        }

        //Operações
        [HttpPost]
        public JsonResult CalculaParcelas(float valor, float frete)
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
                Console.WriteLine(erro);
                return Json(0);
            }
        }

        [HttpPost]
        public JsonResult PagamentoBoleto(EnderecoCliente endereco, Frete frete)
        {
            var carrinho = _reposCarrinho.Buscar();
            var produtos = new List<Produto>();

            var total = 0.0F;

            foreach (var item in carrinho)
            {
                var produto = _reposProduto.Buscar(item.IdProduto);
                produtos.Add(produto);

                total += produto.Valor * item.Quantidade;
            }

            total += frete.Valor;

            try
            {
                var transacao = PreparaTranscao(endereco, frete, produtos, carrinho);

                transacao.PaymentMethod = PaymentMethod.Boleto;
                transacao.Amount = Convert.ToInt32(total.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", ""));

                transacao.Save();

                if (transacao.Id != "0")
                {
                    var pedido = new Pedido
                    {
                        IdTransacao = Convert.ToUInt32(transacao.Id),
                        FormaPagamento = '2',
                        Total = total,
                        Situacao = '0',
                        DataCriacao = DateTime.Now,

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

                    pedido.Cliente = _reposCliente.Buscar();
                    pedido.Frete = frete;

                    pedido.Produto = new List<ProdutoHistorico>();

                    foreach (var item in produtos)
                    {
                        pedido.Produto.Add(new ProdutoHistorico {
                            IdProduto = item.IdProduto,
                            Nome = item.Nome,
                            Valor = item.Valor,
                            Quantidade = carrinho.FirstOrDefault(c =>
                            c.IdProduto == item.IdProduto).Quantidade
                        });
                    }

                    _reposCarrinho.RemoverTodos(_reposCliente.Buscar().IdCliente);

                    return _reposPedido.Registrar(pedido) > 0 ?
                        Json(Convert.ToInt32(transacao.Id)) : Json(0);
                }

                return Json(0);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return Json(0);
            }
        }

        [HttpPost]
        public JsonResult PagamentoCartao(Cartao cartao, EnderecoCliente endereco, Frete frete, byte parcelas)
        {
            var carrinho = _reposCarrinho.Buscar();
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
                        FormaPagamento = '1',
                        Total = total,
                        Situacao = '1',
                        DataCriacao = DateTime.Now,

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

                    pedido.Cliente = _reposCliente.Buscar();
                    pedido.Frete = frete;

                    pedido.Produto = new List<ProdutoHistorico>();

                    foreach (var item in produtos)
                    {
                        pedido.Produto.Add(new ProdutoHistorico
                        {
                            IdProduto = item.IdProduto,
                            Nome = item.Nome,
                            Valor = item.Valor,
                            Quantidade = carrinho.FirstOrDefault(c =>
                            c.IdProduto == item.IdProduto).Quantidade
                        });
                    }

                    _reposCarrinho.RemoverTodos(_reposCliente.Buscar().IdCliente);

                    if (_reposPedido.Registrar(pedido) > 0)
                    {
                        foreach (var produto in produtos)
                        {
                            produto.Estoque -= carrinho.FirstOrDefault(c =>
                            c.IdProduto == produto.IdProduto).Quantidade;

                            _reposProduto.Atualizar(produto);
                        }

                        return Json(Convert.ToInt32(transacao.Id));
                    }
                }

                return Json(0);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return Json(0);
            }
        }

        public Transaction PreparaTranscao(EnderecoCliente endereco, Frete frete, List<Produto> produtos, List<Carrinho> carrinho)
        {
            PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");
            PagarMeService.DefaultEncryptionKey = _configuration.GetValue<string>("Pagamento:DefaultEncryptionKey");

            var cliente = _reposCliente.Buscar();

            var transacao = new Transaction
            {
                Customer = new Customer
                {
                    ExternalId = cliente.IdCliente.ToString(),
                    Name = cliente.Nome,
                    Type = CustomerType.Individual,
                    Country = "br",
                    Email = "rick@morty.com",

                    Documents = new[]
                    {
                        new Document {
                            Type = DocumentType.Cpf,
                            Number = cliente.Cpf
                        }
                    },

                    PhoneNumbers = new string[]
                    {
                        "+5511982738291",
                        "+5511829378291"
                    },

                    Birthday = new DateTime(1991, 12, 12).ToString("yyyy-MM-dd")
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
                    DeliveryDate = frete.Prazo.ToString("yyyy-MM-dd"),
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
                },

                Item = new Item[produtos.Count]
            };

            var i = 0;

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
    }
}