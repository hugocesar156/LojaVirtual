using LojaVirtual.Repositories;
using Microsoft.AspNetCore.Mvc;
using Rastreamento.Authorizations;
using Rastreamento.Sessions;

namespace LojaVirtual.Controllers
{
    [AcessoAutorizacao]
    public class PedidoController : Controller
    {
        private readonly Sessao _sessao;

        private readonly PedidoR _reposPedido;

        public PedidoController(Sessao sessao, PedidoR reposPedido)
        {
            _sessao = sessao;

            _reposPedido = reposPedido;
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
            var lista = _reposPedido.Listar(_sessao.UsuarioSessao().IdCliente);
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
