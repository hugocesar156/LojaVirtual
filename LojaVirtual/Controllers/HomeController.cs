using LojaVirtual.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Sessao sessao)
        {
            Sessao.sessao = sessao;
        }

        public IActionResult Inicio()
        {
            return View();
        }
    }
}
