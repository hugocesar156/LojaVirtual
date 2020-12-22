using LojaVirtual.Repositories;
using LojaVirtual.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoR _reposProduto;

        public HomeController(ProdutoR reposProduto, Sessao sessao)
        {
            _reposProduto = reposProduto;
            Sessao.sessao = sessao;
        }

        public IActionResult Inicio()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lista(uint idCategoria)
        {
            var lista = _reposProduto.ListarPorCategoria(idCategoria);
            return View(lista);
        }
    }
}
