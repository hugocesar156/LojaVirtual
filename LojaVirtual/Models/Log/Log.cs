using Serilog.Core;
using Serilog.Events;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Log
{
    [Table("Logs")]
    public class Log
    {
        public static object Logger { get; internal set; }
        [Key, Column("id")]
        public uint IdLog { get; set; }

        [Column("Timestamp"), MaxLength(100)]
        public string DataHora { get; set; }

        [Column("Level"), MaxLength(15)]
        public string Nivel { get; set; }

        [Column("Message"), MaxLength(50)]
        public string Mensagem { get; set; }

        [Column("Exception"), MaxLength(100)]
        public string Erro { get; set; }

        [Column("Properties"), MaxLength(400)]
        public string Propriedades { get; set; }

        [Column("_ts", TypeName = "TIMESTAMP")]
        public DateTime Ts { get; set; }

        [NotMapped]
        public uint IdUsuario { get; set; }

        [NotMapped]
        public byte Operacao { get; set; }

        [NotMapped]
        public byte Tipo { get; set; }

        [NotMapped]
        public uint IdEntidade { get; set; }
    }
}