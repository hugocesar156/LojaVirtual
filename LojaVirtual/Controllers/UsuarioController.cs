using LojaVirtual.Models.Acesso;
using LojaVirtual.Models.Cliente;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioR _reposUsuario;

        public UsuarioController(UsuarioR reposUsuario)
        {
            _reposUsuario = reposUsuario;
        }

        //Páginas
        public IActionResult Cadastro()
        {
            return View(new Usuario { Cliente = new Cliente() });
        }


        //Operações
        [HttpPost]
        public JsonResult Registrar(Usuario usuario)
        {
            return _reposUsuario.Registrar(usuario) > 0 ? 
                Json(true) : Json(false);
        }
    }
}
