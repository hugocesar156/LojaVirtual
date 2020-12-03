using LojaVirtual.Models.Acesso;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System;
using LojaVirtual.Validations;

namespace LojaVirtual.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioR _reposUsuario;
        private readonly Sessao _sessao;

        public LoginController(UsuarioR reposUsuario, Sessao sessao)
        {
            _reposUsuario = reposUsuario;
            _sessao = sessao;
        }

        //Páginas
        [AnonimoAutorizacao]
        public IActionResult Entrar()
        {
            return View();
        }

        //Operações
        [HttpPost]
        public IActionResult ValidaAcesso(Usuario usuario)
        {
            try
            {
                var usuarioBanco = _reposUsuario.ValidaAcesso(usuario);

                if (usuarioBanco != null)
                {
                    _sessao.Salvar(usuarioBanco, "Acesso");
                    return Json(true);
                }

                return BadRequest(Mensagem.FalhaValidarUsuario);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest(Mensagem.FalhaBanco);
            }
        }

        [AcessoAutorizacao]
        public IActionResult Sair()
        {
            _sessao.Remover("Acesso");
            return View("Entrar");
        }
    }
}
