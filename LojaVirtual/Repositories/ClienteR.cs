using LojaVirtual.Data;
using LojaVirtual.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LojaVirtual.Repositories
{
    public class ClienteR
    {
        private readonly DatabaseContext _banco;

        public ClienteR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public Cliente Buscar(uint idCliente)
        {
            return _banco.Cliente.Include(c => c.Endereco).FirstOrDefault(c => c.IdCliente == idCliente);
        }

        public EnderecoCliente BuscaEndereco(uint idCliente)
        {
            return _banco.Endereco.FirstOrDefault(e => e.IdCliente == idCliente);
        }
    }
}
