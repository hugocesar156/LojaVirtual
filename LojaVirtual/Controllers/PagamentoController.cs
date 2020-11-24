using LojaVirtual.Models.Cliente;
using LojaVirtual.Models.Pagamento;
using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using PagarMe;
using System;
using System.Collections.Generic;

namespace LojaVirtual.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly ClienteR _reposCliente;
        private readonly PagamentoR _reposPagamento;
        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;

        public PagamentoController(ClienteR reposCliente, PagamentoR reposPagamento, 
            ProdutoR reposProduto, CarrinhoR reposCarrinho)
        {
            _reposCliente = reposCliente;
            _reposPagamento = reposPagamento;
            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
        }

        //Operações
        [HttpPost]
        public JsonResult PagamentoCartao(Cartao cartao, Endereco endereco, Frete frete)
        {
            var cliente = _reposCliente.Buscar();

            var carrinho = _reposCarrinho.Buscar();
            var lista = new List<Produto>();

            foreach (var item in carrinho)
                lista.Add(_reposProduto.Buscar(item.IdProduto));

            try
            {
                var transacao = new Transaction
                {
                    Amount = Convert.ToInt32(frete.Valor.ToString().Replace(",", "")),
                    PaymentMethod = PaymentMethod.CreditCard,

                    Card = new Card
                    {
                        Number = cartao.Numero,
                        HolderName = cartao.Nome,
                        ExpirationDate = cartao.Vencimento,
                        Cvv = cartao.Verificador
                    }
                };

                transacao.Card.Save();

                transacao.Customer = new Customer
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
                };

                transacao.Billing = new Billing
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
                };

                transacao.Shipping = new Shipping
                {
                    Name = endereco.Nome,
                    Fee = Convert.ToInt32(frete.Valor.ToString().Replace(",", "")),
                    DeliveryDate = DateTime.Today.AddDays(Convert.ToInt32(frete.Prazo)).ToString("yyyy-MM-dd"),
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
                };

                transacao.Item = new Item[lista.Count];
                var i = 0;

                foreach (var produto in lista)
                {
                    var item = new Item
                    {
                        Id = produto.IdProduto.ToString(),
                        Title = produto.Nome,
                        Quantity = (int)carrinho[i].Quantidade,
                        Tangible = true,
                        UnitPrice = Convert.ToInt32(produto.Valor.ToString().Replace(",", ""))
                    };

                    transacao.Item[i] = item;
                    i++;
                }

                _reposPagamento.PagamentoCartao(transacao);

                return transacao.Id != "0" ?
                    Json(true) : Json(false);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return Json(false);
            }
        }
    }
}
