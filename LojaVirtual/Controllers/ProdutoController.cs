using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using Rastreamento.Authorizations;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class ProdutoController : Controller
    {
        private readonly ProdutoR _reposProduto;
        private static Produto _produto;

        public ProdutoController(ProdutoR reposProduto)
        {
            _reposProduto = reposProduto;
        }

        //Páginas
        public IActionResult Cadastro()
        {
            ViewBag.Categorias = _reposProduto.BuscarCategorias();

            return View(new Produto());
        }

        [HttpGet]
        public IActionResult Edicao(uint id)
        {
            var produto = _reposProduto.Buscar(id);
            _produto = produto;

            ViewBag.Categorias = _reposProduto.BuscarCategorias();

            return View(produto);
        }

        [HttpGet]
        public IActionResult Imagem(uint id)
        {
            var produto = _reposProduto.Buscar(id);
            return View(produto);
        }

        public IActionResult Lista()
        {
            var lista = _reposProduto.ListarPaginado();
            return View(lista);
        }


        //Operações
        [HttpPost]
        public JsonResult Atualizar(Produto produto)
        {
            produto.IdProduto = _produto.IdProduto;
            produto.IdUsuario = _produto.IdUsuario;

            return _reposProduto.Atualizar(produto) > 0 ?
              Json(true) : Json(false);
        }

        [HttpGet]
        public IActionResult OrdenarLista(int pagina, int quantidade, string pesquisa, byte ordenacao)
        {
            var lista = _reposProduto.Listar(pesquisa);

            switch (ordenacao)
            {
                case 1:
                    return PartialView("_Tabela", lista.OrderBy(p => p.Nome).ToPagedList(pagina, quantidade));

                case 2:
                    return PartialView("_Tabela", lista.OrderBy(p => p.Fabricante).ToPagedList(pagina, quantidade));

                case 3:
                    return PartialView("_Tabela", lista.OrderBy(p => p.Modelo).ToPagedList(pagina, quantidade));

                default:
                    return PartialView("_Tabela", lista.ToPagedList(pagina, quantidade));
            }
        }

        [HttpGet]
        public IActionResult PesquisarLista(int pagina, int quantidade, string pesquisa)
        {
            var lista = _reposProduto.ListarPaginado(pagina, quantidade, pesquisa);
            return PartialView("_Tabela", lista);
        }

        [HttpPost]
        public JsonResult Registrar(Produto produto)
        {
            produto.IdUsuario = 1; 

            return _reposProduto.Registrar(produto) > 0 ?
              Json(true) : Json(false);
        }
    }
}
