using LojaVirtual.Data;
using LojaVirtual.Models.Venda;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LojaVirtual.Repositories
{
    public class PedidoR
    {
        private readonly DatabaseContext _banco;

        public PedidoR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public Pedido Buscar(uint idTransacao)
        {
            try
            {
                return _banco.Pedido.Include(p => p.Frete).Include(p => p.Parcelamento)
                    .Include(p => p.Produto).FirstOrDefault(p => p.IdTransacao == idTransacao);
            }
            catch (Exception erro) 
            {
                Console.WriteLine(erro);
                return new Pedido();
            }
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
