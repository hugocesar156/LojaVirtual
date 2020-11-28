using LojaVirtual.Data;
using LojaVirtual.Models.Venda;
using System;

namespace LojaVirtual.Repositories
{
    public class PedidoR
    {
        private readonly DatabaseContext _banco;

        public PedidoR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public int Registrar(Pedido pedido)
        {
            try
            {
                _banco.Add(pedido);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }
    }
}
