using LojaVirtual.Repositories;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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
            return View();
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
                _logger.LogError($"Home/Lista - {erro.Message} ID de usuário: " +
                    $"{_sessao.UsuarioSessao().IdUsuario}");

                throw new Exception(Global.Mensagem.FalhaBanco);
            }
        }
    }
}
