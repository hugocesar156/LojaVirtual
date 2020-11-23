using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using PagarMe;
using System;

namespace LojaVirtual.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly ClienteR _reposCliente;
        private readonly PagamentoR _reposPagamento;

        public PagamentoController(ClienteR reposCliente, PagamentoR reposPagamento)
        {
            _reposCliente = reposCliente;
            _reposPagamento = reposPagamento;
        }

        //Operações
        [HttpPost]
        public JsonResult PagamentoCartao(string numero, string vencimento, string verificador, string cep, string servico)
        {
            var cliente = _reposCliente.Buscar();

            var transacao = new Transaction
            {
                Amount = 2000,
                PaymentMethod = PaymentMethod.CreditCard,

                Card = new Card
                {
                    Number = numero,
                    HolderName = "",
                    ExpirationDate = vencimento,
                    Cvv = verificador
                },

                Customer = new Customer
                {
                    ExternalId = cliente.IdCliente.ToString(),
                    Name = cliente.Nome,
                    Type = CustomerType.Individual,
                    Country = "br",
                    Email = "rick@morty.com",

                    Documents = new[]
                    {
                        new Document{
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
                    Name = "",
                }
            };

            return Json(transacao);
        }
    }
}
