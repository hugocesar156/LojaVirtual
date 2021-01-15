using LojaVirtual.Repositories;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoR _reposProduto;

        public HomeController(Sessao sessao, ProdutoR reposProduto)
        {
            Sessao.sessao = sessao;
            _reposProduto = reposProduto;
        }

        public IActionResult Inicio()
        {
            try
            {
                var categorias = _reposProduto.ListarCategoria();
                return View(categorias);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        public IActionResult MudaCategoria(int pagina)
        {
            try
            {
                var categorias = _reposProduto.ListarCategoria(pagina);
                return PartialView("_Categoria", categorias);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [HttpGet]
        public IActionResult Lista(uint idCategoria)
        {
            try
            {
                var lista = _reposProduto.ListarPorCategoria(idCategoria);
                return View(lista);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Produto, (byte)Global.Acao.Visualizar);
                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }

        public void GerarLogErro(Exception erro, byte entidade, byte acao)
        {
            Log.ForContext("Entidade", entidade).ForContext("Acao", acao).Error(erro, "");
        }
    }
}