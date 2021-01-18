using LojaVirtual.Models.Acesso;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using System;
using LojaVirtual.Validations;
using Serilog;

namespace LojaVirtual.Controllers
{
    public class LoginController : Controller
    {
        private readonly Sessao _sessao;
        private readonly UsuarioR _reposUsuario;

        public LoginController(Sessao sessao, UsuarioR reposUsuario)
        {
            _sessao = sessao;
            _reposUsuario = reposUsuario;
        }

        //Páginas
        [Autorizacao.AnonimoAutorizacao]
        public IActionResult Entrar()
        {
            try
            {
                return View();
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Usuario, (byte)Global.Acao.Redirecionar);
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
                    Sessao.IdPerfil = usuarioBanco.Perfil;

                    GerarLog((byte)Global.Entidade.Usuario, (byte)Global.Acao.Acessar, usuarioBanco.IdUsuario);
                    return Json(new { });
                }

                return BadRequest(Global.Mensagem.FalhaValidarUsuario);
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Usuario, (byte)Global.Acao.Acessar);
                return BadRequest(Global.Mensagem.FalhaBanco);
            }
        }

        [Autorizacao.AcessoAutorizacao]
        public IActionResult Sair()
        {
            try
            {
                _sessao.Remover("Acesso");
                return View("Entrar");
            }
            catch (Exception erro)
            {
                GerarLogErro(erro, (byte)Global.Entidade.Usuario, (byte)Global.Acao.Redirecionar);
                throw new Exception(Global.Mensagem.FalhaRedirecionamento);
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