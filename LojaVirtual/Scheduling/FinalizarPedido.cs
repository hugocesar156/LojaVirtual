using Coravel.Invocable;
using LojaVirtual.Repositories;
using System;
using System.Threading.Tasks;

namespace LojaVirtual.Scheduling
{
    public class FinalizarPedido : IInvocable
    {
        private readonly PedidoR _reposPedido;

        public FinalizarPedido(PedidoR reposPedido)
        {
            _reposPedido = reposPedido;
        }

        public Task Invoke()
        {
            try 
            {
                _reposPedido.FinalizarPedido();
                return Task.CompletedTask;
            }
            catch (Exception erro)
            {
                return Task.FromException(erro);
            }
        }
    }
}
