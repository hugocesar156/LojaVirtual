using LojaVirtual.Models.Acesso;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System;
using LojaVirtual.Validations;
using Microsoft.Extensions.Logging;

namespace LojaVirtual.Controllers
{
    public class LoginController : Controller
    {
        private readonly Sessao _sessao;
        private readonly ILogger<LoginController> _logger;

        private readonly UsuarioR _reposUsuario;

        public LoginController(Sessao sessao, ILogger<LoginController> logger, UsuarioR reposUsuario)
        {
            _sessao = sessao;
            _logger = logger;

            _reposUsuario = reposUsuario;
        }

        //Páginas
        [AnonimoAutorizacao]
        public IActionResult Entrar()
        {
            try
            {
                return View();
            }
            catch (Exception erro)
            {
                _logger.LogError($"Login/Entrar - {erro.Message}");

                throw new Exception(Global.Mensagem.FalhaRedirecionamento);
            }
        }

        //Operações
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ValidaAcesso(Usuario usuario)
        {
            try
            {
                var usuarioBanco = _reposUsuario.ValidaAcesso(usuario);

                if (usuarioBanco != null)
                {
                    _sessao.Salvar(usuarioBanco, "Acesso");
                    return Json(new { });
                }

                return BadRequest(Global.Mensagem.FalhaValidarUsuario);
            }
            catch (Exception erro)
            {
                _logger.LogError($"Login/ValidaAcesso - {erro.Message}");

                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [AcessoAutorizacao]
        public IActionResult Sair()
        {
            try
            {
                _sessao.Remover("Acesso");
                return View("Entrar");
            }
            catch (Exception erro)
            {
                _logger.LogError($"Login/Sair - {erro.Message}");

                throw new Exception(Global.Mensagem.FalhaRedirecionamento);
            }
        }
    }
}