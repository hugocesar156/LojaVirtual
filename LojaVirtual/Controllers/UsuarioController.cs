using LojaVirtual.Models.Acesso;
using LojaVirtual.Models.Cliente;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;
using LojaVirtual.Sessions;

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
            return View(new Usuario { Cliente = new Cliente() });
        }

        [AcessoAutorizacao]
        public IActionResult Perfil()
        {
            var usuario = _reposUsuario.Buscar(_sessao.UsuarioSessao().IdUsuario);
            return View(usuario);
        }


        //Operações
        [HttpPost]
        [AcessoAutorizacao]
        public JsonResult Registrar(Usuario usuario)
        {
            return _reposUsuario.Registrar(usuario) > 0 ? 
                Json(true) : Json(false);
        }
    }
}
