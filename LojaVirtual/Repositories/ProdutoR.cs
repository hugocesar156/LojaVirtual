using LojaVirtual.Data;
using LojaVirtual.Models.Produto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class ProdutoR
    {
        private readonly DatabaseContext _banco;

        public ProdutoR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public int Atualizar(Produto produto)
        {
            _banco.Update(produto);
            return _banco.SaveChanges();
        }

        public Produto Buscar(uint idProduto)
        {
            return _banco.Produto.Include(p => p.Imagem).FirstOrDefault(p => p.IdProduto == idProduto);
        }

        public Dictionary<uint, string> BuscarCategorias()
        {
            return _banco.Categoria.OrderBy(c => c.Nome).ToDictionary(c => c.IdCategoria, c => c.Nome);
        }

        public List<Produto> Listar(string pesquisa = "")
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {
                pesquisa = pesquisa.Trim().ToUpper();

                return _banco.Produto.Include(p => p.Imagem).Where(p =>
                p.Nome.Contains(pesquisa) ||
                p.Fabricante.Contains(pesquisa) ||
                p.Modelo.Contains(pesquisa)).ToList();
            }

            return _banco.Produto.Include(p => p.Imagem).ToList();
        }

        public IPagedList<Produto> ListarPaginado(uint idUsuario, int pagina = 1, int quantidade = 25, string pesquisa = "")
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {
                pesquisa = pesquisa.Trim().ToUpper();

                return _banco.Produto.Include(p => p.Imagem).Where(p =>
                p.Nome.Contains(pesquisa) ||
                p.Fabricante.Contains(pesquisa) ||
                p.Modelo.Contains(pesquisa) && p.IdUsuario == idUsuario)
                    .OrderBy(p => p.Nome).ToPagedList(pagina, quantidade);
            }

            return _banco.Produto.Include(p => p.Imagem).Where(p => p.IdUsuario == idUsuario)
                .OrderBy(p => p.Nome).ToPagedList(pagina, quantidade);
        }

        public IPagedList<Produto> ListarPorCategoria(uint idCategoria, int pagina = 1, string pesquisa = "")
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {
                pesquisa = pesquisa.Trim().ToUpper();

                return _banco.Produto.Include(p => p.Categoria).Include(p => p.Imagem)
               .Where(p => p.IdCategoria == idCategoria && p.Nome.Contains(pesquisa))
               .OrderBy(p => p.Nome).ToPagedList(pagina, 20);
            }

            return _banco.Produto.Include(p => p.Categoria).Include(p => p.Imagem)
                .Where(p => p.IdCategoria == idCategoria).OrderBy(p => p.Nome).ToPagedList(pagina, 20);
        }

        public int Registrar(Produto produto)
        {
            _banco.Add(produto);
            return _banco.SaveChanges();
        }
    }
}