using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Cliente
{
    public class ContatoCliente
    {
        [Key]
        public uint IdContato { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Numero { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }
    }
}
