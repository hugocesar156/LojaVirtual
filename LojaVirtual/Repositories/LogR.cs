using LojaVirtual.Data;
using LojaVirtual.Models.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class LogR
    {
        private readonly DatabaseContext _banco;

        public LogR(DatabaseContext banco)
        {
            _banco = banco;
        }

        public List<Log> BuscarLogUsuario(uint idUsuario)
        {
            try
            {
                var pesquisa = $"Usuario\":\"{idUsuario}"; 

                return _banco.Log.Where(l => l.Ts >= DateTime.Now.AddDays(-7) 
                && l.Propriedades.Contains($"Usuario\":\"{idUsuario}".Replace("\\", ""))).ToList();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Log>();
            }
        }

        public List<Log> BuscarLogErro()
        {
            try
            {
                return _banco.Log.Where(l => l.Ts >= DateTime.Now.AddDays(-7) && l.Nivel == "Error").ToList();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Log>();
            }
        }
    }
}