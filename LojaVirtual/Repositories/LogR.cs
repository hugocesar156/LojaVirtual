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
                var logs = _banco.Log.Where(l => l.Ts >= DateTime.Now.AddDays(-7)).ToList();
                
                foreach (var item in logs)
                {
                    var info = item.Mensagem.Split(" ");

                    item.IdUsuario = Convert.ToUInt32(info[0]);
                    item.Tipo = Convert.ToByte(info[1]);
                    item.Operacao = Convert.ToByte(info[2]);
                    item.IdEntidade = Convert.ToUInt32(info[3]);
                }

                return logs.Where(l => l.IdUsuario == idUsuario).ToList();
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
                var logs = _banco.Log.Where(l => l.Ts >= DateTime.Now.AddDays(-7) && l.Nivel == "Error").ToList();

                foreach (var item in logs)
                {
                    var info = item.Mensagem.Split(" ");

                    item.IdUsuario = Convert.ToUInt32(info[0]);
                    item.Tipo = Convert.ToByte(info[1]);
                    item.Operacao = Convert.ToByte(info[2]);
                    item.IdEntidade = Convert.ToUInt32(info[3]);
                }

                return logs;
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro);
                return new List<Log>();
            }
        }
    }
}