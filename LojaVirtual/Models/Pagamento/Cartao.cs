using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Pagamento
{
    public class Cartao
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Vencimento { get; set; }
        public string Verificador { get; set; }
    }

    public class Parcelamento
    {
        [Key]
        public uint IdParcelamento { get; set; }

        [Required]
        public byte Parcelas { get; set; }

        [Column(TypeName = "FLOAT"), Required]
        public float ValorParcela { get; set; }

        [Column(TypeName = "FLOAT"), Required]
        public float ValorTotal { get; set; }

        [Required]
        public bool Juros { get; set; }
    }
}
