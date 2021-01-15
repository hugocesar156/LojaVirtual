using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Log
{
    [Table("Logs")]
    public class Log
    {
        [Key, Column("id")]
        public int IdLog { get; set; }

        [Column("Timestamp"), MaxLength(100)]
        public DateTime DataHora { get; set; }

        [Column("Level"), MaxLength(15)]
        public string Nivel { get; set; }

        [Column("Message"), MaxLength(50)]
        public string Mensagem { get; set; }

        [Column("Exception"), MaxLength(100)]
        public string Erro { get; set; }

        [Column("Properties"), MaxLength(400)]
        public string Propriedades { get; set; }

        [NotMapped]
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