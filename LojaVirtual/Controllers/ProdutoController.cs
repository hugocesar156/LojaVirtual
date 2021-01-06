using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System.Linq;
using X.PagedList;
using System;
using LojaVirtual.Validations;
using Microsoft.Extensions.Logging;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class ProdutoController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ILogger<ProdutoController> _logger;

        private readonly ProdutoR _reposProduto;

        public ProdutoController(Sessao sessao, ILogger<ProdutoController> logger, ProdutoR reposProduto)
        {
            _sessao = sessao;
            _logger = logger;

            _reposProduto = reposProduto;
        }

        //Páginas
        public IActionResult Cadastro()
        {
            try
            {
                ViewBag.Categorias = _reposProduto.BuscarCategorias();
                return View(new Produto());
            }
            catch (Exception erro)
            {
                _logger.LogError($"Produto/Cadastro - {erro.Message} ID de usuário: " +
                  $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult Edicao(uint id)
        {
            try
            {
                var produto = _reposProduto.Buscar(id);

                if (produto.IdUsuario != _sessao.UsuarioSessao().IdUsuario)
                    return RedirectToAction("Incio", "Home");

                ViewBag.Categorias = _reposProduto.BuscarCategorias();
                return View(produto);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Produto/Edicao - {erro.Message} ID de usuário: " +
                  $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult Imagem(uint id)
        {
            try
            {
                var produto = _reposProduto.Buscar(id);

                if (produto.IdUsuario != _sessao.UsuarioSessao().IdUsuario)
                    return RedirectToAction("Incio", "Home");

                return View(produto);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Produto/Imagem - {erro.Message} ID de usuário: " +
                 $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        public IActionResult Lista()
        {
            try
            {
                var lista = _reposProduto.ListarPaginado(_sessao.UsuarioSessao().IdUsuario);
                return View(lista);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Produto/Lista - {erro.Message} ID de usuário: " +
                    $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }


        //Operações
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar(Produto produto)
        {
            try
            {
                produto.IdUsuario = _sessao.UsuarioSessao().IdUsuario;

                if (_reposProduto.Atualizar(produto) > 0)
                    return Json(produto.IdProduto);

                return BadRequest(Global.Mensagem.FalhaAtualizacao);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Produto/Atualizar - {erro.Message} ID de usuário: " +
                    $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult OrdenarLista(int pagina, int quantidade, string pesquisa, byte ordenacao)
        {
            try
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
            catch (Exception erro)
            {
                _logger.LogError($"Produto/OrdenarLista - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult PesquisarLista(int pagina, int quantidade, string pesquisa)
        {
            try
            {
                var lista = _reposProduto.ListarPaginado(_sessao.UsuarioSessao().IdUsuario, pagina, quantidade, pesquisa);
                return PartialView("_Tabela", lista);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Produto/PesquisarLista - {erro.Message} ID de usuário: " +
                   $"{_sessao.UsuarioSessao().IdUsuario}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(Produto produto)
        {
            try
            {
                produto.IdUsuario = _sessao.UsuarioSessao().IdUsuario;

                if (_reposProduto.Registrar(produto) > 0)
                    return Json(produto.IdProduto);

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
