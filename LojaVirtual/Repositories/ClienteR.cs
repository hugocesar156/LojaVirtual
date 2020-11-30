using LojaVirtual.Data;
using LojaVirtual.Models.Cliente;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteR
    {
        private readonly DatabaseContext _banco;

        public ClienteR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public Cliente Buscar()
        {
            try
            {
                return _banco.Cliente.Include(c => c.Endereco)
                    .FirstOrDefault(c => c.IdCliente == 1);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new Cliente();
            }
        }

        public EnderecoCliente BuscaEndereco()
        {
            try
            {
                return _banco.Endereco.FirstOrDefault(e => e.IdCliente == 1);
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new EnderecoCliente();
            }
        }
    }
}
