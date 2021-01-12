using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Repositories;
using LojaVirtual.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class LogController : Controller
    {
        private readonly Sessao _sessao;
        private readonly LogR _reposLog;

        public LogController(Sessao sessao, LogR reposLog)
        {
            _sessao = sessao;
            _reposLog = reposLog;
        }

        public IActionResult LogUsuario()
        {
            var logs = _reposLog.BuscarLogUsuario(_sessao.UsuarioSessao().IdUsuario);
            return Json(logs);
        }

        public IActionResult LogErro()
        {
            var logs = _reposLog.BuscarLogErro();
            return Json(logs);
        }
    }
}
