using LojaVirtual.Data;
using LojaVirtual.Models.Acesso;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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

        public int Registrar(Usuario usuario)
        {
            try
            {
                _banco.Add(usuario);
                return _banco.SaveChanges();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return 0;
            }
        }

        public Usuario ValidaAcesso(Usuario usuario)
        {
            try
            {
                return _banco.Usuario.FirstOrDefault(u => 
                u.Email == usuario.Email && u.Senha == usuario.Senha);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new Usuario();
            }
        }
    }
}
