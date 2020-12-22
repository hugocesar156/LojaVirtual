using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System.Linq;
using X.PagedList;
using System;
using LojaVirtual.Validations;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class ProdutoController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ProdutoR _reposProduto;

        public ProdutoController(Sessao sessao, ProdutoR reposProduto)
        {
            _sessao = sessao;
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

            if (produto.IdUsuario != _sessao.UsuarioSessao().IdUsuario)
                return RedirectToAction("Incio", "Home");

            ViewBag.Categorias = _reposProduto.BuscarCategorias();
            return View(produto);
        }

        [HttpGet]
        public IActionResult Imagem(uint id)
        {
            var produto = _reposProduto.Buscar(id);

            if (produto.IdUsuario != _sessao.UsuarioSessao().IdUsuario)
                return RedirectToAction("Incio", "Home");

            return View(produto);
        }

        public IActionResult Lista()
        {
            var lista = _reposProduto.ListarPaginado(_sessao.UsuarioSessao().IdUsuario);
            return View(lista);
        }


        //Operações
        [HttpPost]
        public JsonResult Atualizar(Produto produto)
        {
            produto.IdUsuario = _sessao.UsuarioSessao().IdUsuario;

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
            var lista = _reposProduto.ListarPaginado(_sessao.UsuarioSessao().IdUsuario, pagina, quantidade, pesquisa);
            return PartialView("_Tabela", lista);
        }

        [HttpPost]
        public IActionResult Registrar(Produto produto)
        {
            try
            {
                produto.IdUsuario = _sessao.UsuarioSessao().IdUsuario;

                if (_reposProduto.Registrar(produto) > 0)
                    return Json(new { });

                return BadRequest(Global.Mensagem.FalhaCadastro);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }
    }
}
