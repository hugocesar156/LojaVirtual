using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Pagamento(string valorFrete, char tipoFrete)
        {
            var carrinho = _reposCarrinho.Buscar();
            var produtos = new List<Produto>();

            foreach (var item in carrinho)
                produtos.Add(_reposProduto.Buscar(item.IdProduto));

            ViewBag.Quantidade = carrinho.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            ViewBag.Frete = valorFrete;
            ViewBag.Tipo = tipoFrete;

            return View(produtos);
        }
    }
}
