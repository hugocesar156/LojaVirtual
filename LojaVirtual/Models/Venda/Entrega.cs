using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Venda
{
    public class Frete
    {
        [Key]
        public uint IdFrete { get; set; }

        [Column(TypeName = "FLOAT"), Required]
        public float Valor { get; set; }

        [Required]
        public byte DiasEntrega { get; set; }

        [Column(TypeName = "CHAR(1)"), Required]
        public char Servico { get; set; }
    }

    public class Pacote
    {
        public uint Largura { get; set; }
        public uint Altura { get; set; }
        public uint Comprimento { get; set; }
        public float Peso { get; set; }
    }
}
