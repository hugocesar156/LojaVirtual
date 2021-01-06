using LojaVirtual.Repositories;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ILogger<HomeController> _logger;

        private readonly ProdutoR _reposProduto;

        public HomeController(ProdutoR reposProduto, Sessao sessao, ILogger<HomeController> logger)
        {
            Sessao.sessao = sessao;

            _sessao = sessao;
            _logger = logger;
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
                _logger.LogError($"Home/Inicio - {erro.Message}");

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
                _logger.LogError($"Home/MudaCategoria - {erro.Message}");

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
                _logger.LogError($"Home/Lista - {erro.Message}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }
    }
}
