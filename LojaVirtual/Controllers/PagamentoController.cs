using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using PagarMe;
using LojaVirtual.Models.Cliente;

namespace LojaVirtual.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;

        public PagamentoController(ProdutoR reposProduto, CarrinhoR reposCarrinho)
        {
            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
        }

        //Páginas
        [HttpPost]
        public IActionResult Pagamento(float valorTotal, float valorFrete, char tipoFrete)
        {
            var carrinho = _reposCarrinho.Buscar();
            var produtos = new List<Produto>();

            foreach (var item in carrinho)
                produtos.Add(_reposProduto.Buscar(item.IdProduto));

            ViewBag.Quantidade = carrinho.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            ViewBag.Total = valorTotal.ToString("C");
            ViewBag.Frete = valorFrete.ToString("C");

            if (tipoFrete == '1')
                ViewBag.Tipo = "SEDEX";
            else
                ViewBag.Tipo = "PAC";

            return View(produtos);
        }


        //Operações
        public JsonResult RealizarPagamento(char pagamento)
        {
            var cliente = new Cliente();

            var transacao = new Transaction
            {
                Amount = 2000,
                PaymentMethod = PaymentMethod.Boleto,

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
                }
            };

            if (pagamento == '1')
                PagamentoR.GerarBoleto(transacao);
            else
                PagamentoR.PagamentoCartao(transacao);

            return Json(transacao);
        }
    }
}
