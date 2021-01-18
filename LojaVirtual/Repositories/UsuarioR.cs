using LojaVirtual.Data;
using LojaVirtual.Models.Acesso;
using Microsoft.EntityFrameworkCore;
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
            return _banco.Usuario.Include(u => u.Cliente.Endereco)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public List<Usuario> Listar(string pesquisa = "")
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

        public IPagedList<Usuario> ListarPaginado(int pagina = 1, int quantidade = 25, string pesquisa = "")
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

        public int Registrar(Usuario usuario)
        {
            _banco.Add(usuario);
            return _banco.SaveChanges();
        }

        public Usuario ValidaAcesso(Usuario usuario)
        {
            return _banco.Usuario.FirstOrDefault(u => u.Email == usuario.Email && u.Senha == usuario.Senha);
        }

        public bool ValidaEmail(string email)
        {
            return _banco.Usuario.FirstOrDefault(u => u.Email == email) == null;
        }
    }
}
