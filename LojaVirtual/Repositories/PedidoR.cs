using LojaVirtual.Data;
using LojaVirtual.Models.Pagamento;
using LojaVirtual.Models.Venda;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

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
                return _banco.Pedido
                    .Include(p => p.Frete).Include(p => p.Parcelamento)
                    .Include(p => p.Boleto).Include(p => p.Endereco)
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

        public IPagedList<Pedido> Listar(uint idCliente)
        {
            try
            {
                return _banco.Pedido.Where(p => p.IdCliente == idCliente).Include(p => p.Boleto)
                    .OrderByDescending(p => p.DataCriacao).ToPagedList(1, 10);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);

                var lista = new List<Pedido>();
                return lista.ToPagedList();
            }
        }
    }
}
