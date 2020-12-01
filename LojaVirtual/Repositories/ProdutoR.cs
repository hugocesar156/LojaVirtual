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
            try
            {
                _banco.Update(produto);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }

        public Produto Buscar(uint idProduto)
        {
            try
            {
                return _banco.Produto.Include(p => p.Imagem)
                    .FirstOrDefault(p => p.IdProduto == idProduto);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new Produto();
            }
        }

        public Dictionary<uint, string> BuscarCategorias()
        {
            try
            {
                return _banco.Categoria.OrderBy(c => c.Nome)
                    .ToDictionary(c => c.IdCategoria, c => c.Nome);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new Dictionary<uint, string>();
            }
        }

        public IPagedList<Produto> ListarPaginado(uint idUsuario, int pagina = 1, int quantidade = 25, string pesquisa = "")
        {
            try
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
            catch (Exception erro)
            {
                Console.WriteLine(erro);

                var lista = new List<Produto>();
                return lista.ToPagedList();
            }
        }

        public List<Produto> Listar(string pesquisa = "")
        {
            try
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
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Produto>();
            }
        }

        public int Registrar(Produto produto)
        {
            try
            {
                _banco.Add(produto);
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
