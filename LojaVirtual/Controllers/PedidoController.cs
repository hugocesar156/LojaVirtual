using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoR _reposPedido;

        public PedidoController(PedidoR reposPedido)
        {
            _reposPedido = reposPedido;
        }

        public IActionResult Menu(uint idTransacao)
        {
            var pedido = _reposPedido.Buscar(idTransacao);

            return View(pedido);
        }
    }
}
