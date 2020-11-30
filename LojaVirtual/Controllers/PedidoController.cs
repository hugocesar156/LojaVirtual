using LojaVirtual.Models.Pagamento;
using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoR _reposPedido;
        private readonly ClienteR _reposCliente;

        public PedidoController(PedidoR reposPedido, ClienteR reposCliente)
        {
            _reposPedido = reposPedido;
            _reposCliente = reposCliente;
        }

        //Páginas
        [HttpGet]
        public IActionResult Detalhe(uint id)
        {
            var pedido = _reposPedido.Buscar(id);
            return View(pedido);
        }

        public IActionResult Lista()
        {
            var lista = _reposPedido.Listar(_reposCliente.Buscar().IdCliente);
            return View(lista);
        }

        //Operações
        public static string SituacaoPedido(char situacao)
        {
            switch (situacao)
            {
                case '1':
                    return "Em espera";
                case '2':
                    return "Aguardando pagamento";
                case '3':
                    return "Extornado";
                case '4':
                    return "Recusado";
                case '5':
                    return "Enviado";
                case '6':
                    return "Entregue";
                default:
                    return string.Empty;
            }
        }
    }
}
