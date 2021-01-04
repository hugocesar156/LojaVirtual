using LojaVirtual.Data;
using LojaVirtual.Models.Venda;
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

        public int AdicionarItem(Carrinho carrinho)
        {
            _banco.Add(carrinho);
            return _banco.SaveChanges();
        }

        public int Atualizar(Carrinho item, byte operacao)
        {
            /* 1- Adicionar item; 2- Remover item */
            if (operacao == 1)
                item.Quantidade++;
            else
                item.Quantidade--;

            _banco.Update(item);
            return _banco.SaveChanges();
        }

        public List<Carrinho> Buscar(uint idCliente)
        {
            return _banco.Carrinho.Where(c => c.IdCliente == idCliente).ToList();
        }

        public int RemoverItem(Carrinho item)
        {
            _banco.Remove(item);
            return _banco.SaveChanges();
        }

        public int RemoverTodos(uint idCliente)
        {
            var carrinho = _banco.Carrinho.Where(c => c.IdCliente == idCliente);

            foreach (var item in carrinho)
                _banco.Remove(item);

            return _banco.SaveChanges();
        }
    }
}
