using LojaVirtual.Data;
using LojaVirtual.Models.Acesso;
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
