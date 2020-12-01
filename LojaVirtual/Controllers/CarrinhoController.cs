using LojaVirtual.Models.Produto;
using LojaVirtual.Models.Venda;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using Rastreamento.Authorizations;
using Rastreamento.Sessions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class CarrinhoController : Controller
    {
        private readonly Sessao _sessao;

        private readonly ProdutoR _reposProduto;
        private readonly CarrinhoR _reposCarrinho;
        private readonly FreteR _reposFrete;
        private readonly ClienteR _reposCliente;

        private static List<Carrinho> _carrinho;

        public CarrinhoController(Sessao sessao, ProdutoR reposProduto, CarrinhoR reposCarrinho, 
            FreteR reposFrete, ClienteR reposCliente)
        {
            _sessao = sessao;

            _reposProduto = reposProduto;
            _reposCarrinho = reposCarrinho;
            _reposFrete = reposFrete;
            _reposCliente = reposCliente;
        }

        //Páginas
        public IActionResult Menu()
        {
            var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);
            var produtos = new List<Produto>();

            foreach (var item in carrinho)
                produtos.Add(_reposProduto.Buscar(item.IdProduto));

            _carrinho = carrinho;

            ViewBag.Quantidade = carrinho.ToDictionary(i => i.IdProduto, i => i.Quantidade);

            ViewBag.Cep = _reposCliente.BuscaEndereco().Cep;
         
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
        public async Task<JsonResult> CalcularFrete(string cep, string servico)
        {
            var lista = new List<Produto>();
            var carrinho = _reposCarrinho.Buscar(_sessao.UsuarioSessao().IdCliente);

            var quantidade = new Dictionary<uint, uint>();

            foreach (var item in carrinho)
            {
                lista.Add(_reposProduto.Buscar(item.IdProduto));
                quantidade.Add(item.IdProduto, item.Quantidade);
            }

            return Json(await _reposFrete.CalcularFrete(cep, FreteR.PrepararPacotes(lista, quantidade), servico));
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
            else if (_reposCarrinho.RemoverItem(item) > 0)
            {
                _carrinho.Remove(item);
                return PartialView("_Carrinho", BuscaProdutosCarrinho(_carrinho));
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