using System;
using Coravel.Invocable;
using System.Threading.Tasks;
using LojaVirtual.Repositories;

namespace LojaVirtual.Scheduling
{
    public class Pedido : IInvocable
    {
        private readonly PedidoR _reposPedido;

        public Pedido(PedidoR reposPedido)
        {
            _reposPedido = reposPedido;
        }

        public Task Invoke()
        {
            try
            {
                _reposPedido.AtualizarPedidos();
                return Task.CompletedTask;
            }
            catch (Exception erro)
            {
                return Task.FromException(erro);
            }
        }
    }
}
