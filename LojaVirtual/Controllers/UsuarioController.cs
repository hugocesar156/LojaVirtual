using System;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models.Acesso;
using LojaVirtual.Models.Cliente;
using LojaVirtual.Repositories;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;
using LojaVirtual.Validations;

namespace LojaVirtual.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Sessao _sessao;
        private readonly UsuarioR _reposUsuario;

        public UsuarioController(Sessao sessao, UsuarioR reposUsuario)
        {
            _sessao = sessao;
            _reposUsuario = reposUsuario;
        }

        //Páginas
        public IActionResult Cadastro()
        {
            ViewBag.Estados = new string[]
            {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA",
                "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN",
                "RO", "RR", "RS", "SC", "SE", "SP", "TO"
            };

            return View(new Usuario { Cliente = new Cliente() });
        }

        public IActionResult Lista()
        {
            var lista = _reposUsuario.ListarPaginado();
            return View(lista);
        }

        [AcessoAutorizacao]
        public IActionResult Perfil()
        {
            var usuario = _reposUsuario.Buscar(_sessao.UsuarioSessao().IdUsuario);
            return View(usuario);
        }


        //Operações
        [HttpPost]
        public IActionResult ValidaUsuario(Usuario usuario)
        {
            try
            {
                return Json(_reposUsuario.ValidaEmail(usuario.Email));
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return BadRequest(Mensagem.FalhaBanco);
            }
        }

        [HttpPost]
        public JsonResult Registrar(Usuario usuario)
        {
            if (usuario.Cliente.Endereco.Complemento == null)
                usuario.Cliente.Endereco.Complemento = "";

            return _reposUsuario.Registrar(usuario) > 0 ? 
                Json(true) : Json(false);
        }
    }
}
