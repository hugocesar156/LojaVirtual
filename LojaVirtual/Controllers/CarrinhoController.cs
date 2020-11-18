using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;
        private readonly FreteR _reposFrete;

        private static List<Carrinho> _carrinho;

        public CarrinhoController(ProdutoR reposProduto, CarrinhoR reposCarrinho, FreteR reposFrete)
        {
            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
            _reposFrete = reposFrete;
        }

        //Páginas
        public IActionResult Menu()
        {
            var carrinho = _reposCarrinho.Buscar();
            var produtos = new List<Produto>();

            foreach (var item in carrinho)
                produtos.Add(_reposProduto.Buscar(item.IdProduto));

            _carrinho = carrinho;

            ViewBag.Quantidade = carrinho.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            return View(produtos);
        }


        //Operações
        [HttpGet]
        public IActionResult AdicionarQuantidade(uint id)
        {
            var item = _carrinho.FirstOrDefault(c => c.IdProduto == id);

            if (_reposProduto.Buscar(id).Estoque > item.Quantidade)
            {
                if (_reposCarrinho.Atualizar(item, 1) > 0)
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<JsonResult> CalcularFrete(string cep)
        {
            var lista = new List<Produto>();
            var carrinho = _reposCarrinho.Buscar();

            var quantidade = new Dictionary<uint, uint>();

            foreach (var item in carrinho)
            {
                lista.Add(_reposProduto.Buscar(item.IdProduto));
                quantidade.Add(item.IdProduto, item.Quantidade);
            }

            return Json(await _reposFrete.CalcularFrete(cep, FreteR.PrepararPacotes(lista, quantidade)));
        }

        [HttpGet]
        public IActionResult RetirarQuantidade(uint id)
        {
            var item = _carrinho.FirstOrDefault(c => c.IdProduto == id);

            if (item.Quantidade > 1)
            {
                if (_reposCarrinho.Atualizar(item, 2) > 0)
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
            }
            else
            {
                if (_reposCarrinho.RemoverItem(item) > 0)
                {
                    _carrinho.Remove(item);
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult RemoverItem(uint id)
        {
            var item = _carrinho.FirstOrDefault(c => c.IdProduto == id);

            if (_reposCarrinho.RemoverItem(item) > 0)
            {
                _carrinho.Remove(item);
                return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
            }

            return BadRequest();
        }

        public List<Produto> BuscaProdutosCarrinho(List<Carrinho> itens)
        {
            var carrinho = new List<Produto>();

            foreach (var item in itens)
                carrinho.Add(_reposProduto.Buscar(item.IdProduto));

            ViewBag.Quantidade = itens.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            return carrinho;
        }
    }
}
