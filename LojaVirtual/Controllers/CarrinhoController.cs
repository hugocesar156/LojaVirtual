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

        private static List<Carrinho> _itens;

        public CarrinhoController(ProdutoR reposProduto, CarrinhoR reposCarrinho, FreteR reposFrete)
        {
            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
            _reposFrete = reposFrete;
        }

        //Páginas
        public IActionResult Menu()
        {
            var itens = _reposCarrinho.Buscar();
            var carrinho = new List<Produto>();

            foreach (var item in itens)
                carrinho.Add(_reposProduto.Buscar(item.IdProduto));

            _itens = itens;

            ViewBag.Quantidade = itens.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            return View(carrinho);
        }


        //Operações
        [HttpGet]
        public IActionResult AdicionarQuantidade(uint id)
        {
            var item = _itens.FirstOrDefault(c => c.IdProduto == id);

            if (_reposProduto.Buscar(id).Estoque > item.Quantidade)
            {
                if (_reposCarrinho.Atualizar(item, 1) > 0)
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_itens));
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
            var item = _itens.FirstOrDefault(c => c.IdProduto == id);

            if (item.Quantidade > 1)
            {
                if (_reposCarrinho.Atualizar(item, 2) > 0)
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_itens));
            }
            else
            {
                if (_reposCarrinho.RemoverItem(item) > 0)
                {
                    _itens.Remove(item);
                    return PartialView("_Carrinho", BuscaProdutosCarrinho(_itens));
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult RemoverItem(uint id)
        {
            var item = _itens.FirstOrDefault(c => c.IdProduto == id);

            if (_reposCarrinho.RemoverItem(item) > 0)
            {
                _itens.Remove(item);
                return PartialView("_Carrinho", BuscaProdutosCarrinho(_itens));
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
