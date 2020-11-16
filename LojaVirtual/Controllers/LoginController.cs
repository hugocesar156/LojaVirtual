using LojaVirtual.Models.Acesso;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LojaVirtual.Controllers
{
    public class LoginController : Controller
    {
        //Páginas
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
                /* 0 - Acesso validado
                  1 - Email inválido
                  2 - Senha incorreta 
                  3 - Erro */

                if (usuario.Email != "admin")
                    return Json(1);

                else if (usuario.Senha != "123456")
                    return Json(2);

                return Json(0);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return Json(3);
            }
        }
    }
}
