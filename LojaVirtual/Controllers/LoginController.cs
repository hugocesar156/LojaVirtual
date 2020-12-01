using LojaVirtual.Models.Acesso;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using Rastreamento.Authorizations;
using Rastreamento.Sessions;
using System;

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

                return Json(false);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return Json(false);
            }
        }
    }
}
