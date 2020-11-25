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

namespace LojaVirtual.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly ClienteR _reposCliente;
        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;

        private readonly IConfiguration _configuration;

        public PagamentoController(ClienteR reposCliente, ProdutoR reposProduto, 
            CarrinhoR reposCarrinho, IConfiguration configuration)
        {
            _reposCliente = reposCliente;
            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;

            _configuration = configuration;
        }

        //Operações
        [HttpPost]
        public JsonResult PagamentoCartao(Cartao cartao, Endereco endereco, Frete frete)
        {
            var cliente = _reposCliente.Buscar();

            var carrinho = _reposCarrinho.Buscar();
            var lista = new List<Produto>();

            var total = 0.0F;

            foreach (var item in carrinho)
            {
                var produto = _reposProduto.Buscar(item.IdProduto);
                lista.Add(produto);

                total += produto.Valor * item.Quantidade;
            }

            total += frete.Valor;
                
            try
            {
                PagarMeService.DefaultApiKey = _configuration.GetValue<string>("Pagamento:DefaultApiKey");
                PagarMeService.DefaultEncryptionKey = _configuration.GetValue<string>("Pagamento:DefaultEncryptionKey");

                var transacao = new Transaction
                {
                    Amount = Convert.ToInt32(total.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", "")),
                    PaymentMethod = PaymentMethod.CreditCard,

                    Card = new Card
                    {
                        HolderName = cartao.Nome,
                        Number = cartao.Numero,
                        ExpirationDate = cartao.Vencimento.Replace("/", ""),
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
                    Fee = Convert.ToInt32(frete.Valor.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", "")),
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
                        UnitPrice = Convert.ToInt32(produto.Valor.ToString("C").Replace("R$", "").Replace(".", "").Replace(",", ""))
                    };

                    transacao.Item[i] = item;
                    i++;
                }

                transacao.Save();

                return transacao.Id != "0" ? Json(true) : Json(false);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return Json(false);
            }
        }
    }
}