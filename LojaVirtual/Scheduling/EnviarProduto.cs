using Coravel.Invocable;
using LojaVirtual.Repositories;
using System;
using System.Threading.Tasks;

namespace LojaVirtual.Scheduling
{
    public class EnviarProduto : IInvocable
    {
        private readonly PedidoR _reposPedido;

        public EnviarProduto(PedidoR reposPedido)
        {
            _reposPedido = reposPedido;
        }

        public Task Invoke()
        {
            try
            {
                _reposPedido.EnviarProdutosPedido();
                return Task.CompletedTask;
            }
            catch (Exception erro)
            {
                return Task.FromException(erro);
            }
        }
    }
}
