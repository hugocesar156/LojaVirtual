using LojaVirtual.Models.Produto;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System.Linq;
using X.PagedList;
using System;
using LojaVirtual.Validations;
using Serilog;

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
            try
            {
                ViewBag.Categorias = _reposProduto.BuscarCategorias();
                return View(new Produto());
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Inserir);
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
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Editar);
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
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Editar);
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
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
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
                {
                    GerarLog((byte)Global.Entidade.Produto, (byte)Global.Acao.Editar, produto.IdProduto);
                    return Json(produto.IdProduto);
                }

                return BadRequest(Global.Mensagem.FalhaAtualizacao);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Editar);
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
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
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
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
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
                {
                    GerarLog((byte)Global.Entidade.Produto, (byte)Global.Acao.Inserir, produto.IdProduto);
                    return Json(produto.IdProduto);
                }
                    
                return BadRequest(Global.Mensagem.FalhaCadastro);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Inserir);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        public void GerarLog(byte entidade, byte acao, uint objeto)
        {
            Log.ForContext("Usuario", Convert.ToString(_sessao.UsuarioSessao().IdUsuario))
                       .ForContext("Entidade", entidade).ForContext("Acao", acao).ForContext("Objeto", objeto).Information("");
        }

        public void GerarLogErro(Exception erro, byte entidade, byte acao)
        {
            Log.ForContext("Usuario", Convert.ToString(_sessao.UsuarioSessao().IdUsuario))
                       .ForContext("Entidade", entidade).ForContext("Acao", acao).Error(erro, "");
        }
    }
}