﻿using Coravel.Invocable;
using LojaVirtual.Repositories;
using System;
using System.Threading.Tasks;

namespace LojaVirtual.Scheduling
{
    public class AtualizarProduto : IInvocable
    {
        private readonly PedidoR _reposPedido;

        public AtualizarProduto(PedidoR reposPedido) 
        {
            _reposPedido = reposPedido;
        }

        public Task Invoke()
        {
            try
            {
                _reposPedido.AtualizarProdutoPedido();
                return Task.CompletedTask;
            }
            catch (Exception erro)
            {
                return Task.FromException(erro);
            }
        }
    }
}
