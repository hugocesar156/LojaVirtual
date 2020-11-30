using LojaVirtual.Data;
using LojaVirtual.Models.Venda;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Repositories
{
    public class CarrinhoR
    {
        private readonly DatabaseContext _banco;

        public CarrinhoR (DatabaseContext banco)
        {
            _banco = banco;
        }

        public int Atualizar(Carrinho item, byte operacao)
        {
            try
            {
                /* 1- Adicionar item; 2- Remover item */
                if (operacao == 1)
                    item.Quantidade++;
                else
                    item.Quantidade--;

                _banco.Update(item);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }

        public List<Carrinho> Buscar()
        {
            try
            {
                return _banco.Carrinho.Where(c => c.IdCliente == 1).ToList();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Carrinho>();
            }
        }

        public int RemoverItem(Carrinho item)
        {
            try
            {
                _banco.Remove(item);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }

        public int RemoverTodos(uint idCliente)
        {
            try
            {
                var carrinho = _banco.Carrinho.Where(c => c.IdCliente == idCliente);

                foreach (var item in carrinho)
                    _banco.Remove(item);

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
