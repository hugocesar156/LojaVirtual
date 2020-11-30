using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Pagamento
{
    public class Boleto
    {
        [Key]
        public uint IdBoleto { get; set; }

        [Column(TypeName = "DATETIME"), Required]
        public DateTime DataExpiracao { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string CodigoBarras { get; set; }
    }
}
