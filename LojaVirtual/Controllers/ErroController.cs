using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ErroController : Controller
    {
        public IActionResult Mensagem()
        {
            ViewBag.Erro = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error.Message;
            return View();
        }
    }
}
