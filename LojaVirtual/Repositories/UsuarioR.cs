using LojaVirtual.Data;
using LojaVirtual.Models.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class UsuarioR
    {
        private readonly DatabaseContext _banco;

        public UsuarioR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public Usuario Buscar(uint idUsuario)
        {
            try
            {
                return _banco.Usuario.Include(u => u.Cliente.Endereco)
                    .FirstOrDefault(u => u.IdUsuario == idUsuario);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new Usuario();
            }
        }

        public bool Registrar(Usuario usuario)
        {
            _banco.Add(usuario);
            return _banco.SaveChanges() > 0;
        }

        public List<Usuario> Listar(string pesquisa = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(pesquisa))
                {
                    pesquisa = pesquisa.Trim().ToUpper();

                    return _banco.Usuario.Include(u => u.Cliente.Contato).Where(u =>
                    u.Email.Contains(pesquisa) ||
                    u.Cliente.Nome.Contains(pesquisa) ||
                    u.Cliente.Cpf.Contains(pesquisa) ||
                    u.Cliente.Contato[0].Numero.Contains(pesquisa)).ToList();
                }

                return _banco.Usuario.Include(u => u.Cliente.Contato).ToList();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Usuario>();
            }
        }

        public IPagedList<Usuario> ListarPaginado(int pagina = 1, int quantidade = 25, string pesquisa = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(pesquisa))
                {
                    pesquisa = pesquisa.Trim().ToUpper();

                    return _banco.Usuario.Include(u => u.Cliente.Contato).Where(u =>
                    u.Email.Contains(pesquisa) ||
                    u.Cliente.Nome.Contains(pesquisa) ||
                    u.Cliente.Cpf.Contains(pesquisa) || 
                    u.Cliente.Contato[0].Numero.Contains(pesquisa)) 
                        .OrderBy(u => u.Cliente.Nome).ToPagedList(pagina, quantidade);
                }

                return _banco.Usuario.Include(p => p.Cliente.Contato)
                    .OrderBy(u => u.Cliente.Nome).ToPagedList(pagina, quantidade);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);

                var lista = new List<Usuario>();
                return lista.ToPagedList();
            }
        }

        public Usuario ValidaAcesso(Usuario usuario)
        {
            return _banco.Usuario.FirstOrDefault(u =>
               u.Email == usuario.Email && u.Senha == usuario.Senha);
        }

        public bool ValidaEmail(string email)
        {
            return _banco.Usuario.FirstOrDefault(u => u.Email == email) == null;
        }
    }
}
