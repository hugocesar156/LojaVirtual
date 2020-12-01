﻿using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Authorizations;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class ClienteController : Controller
    {
        //Páginas
        public IActionResult Endereco()
        {
            ViewBag.Estados = new string[]
            {
                "AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA",
                "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN",
                "RO", "RR", "RS", "SC", "SE", "SP", "TO"
            };

            return View();
        }
    }
}
