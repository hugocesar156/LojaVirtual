using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Cliente
{
    public class Endereco
    {
        [Key]
        public uint IdEndereco { get; set; }

        [Required, MaxLength(8)]
        public string Cep { get; set; }

        [Required, MaxLength(30)]
        public string Logradouro { get; set; }

        [Required, MaxLength(5)]
        public string Numero { get; set; }

        [Required, MaxLength(30)]
        public string Cidade { get; set; }

        [Required, MaxLength(30)]
        public string Bairro { get; set; }

        [Required, MaxLength(20)]
        public string Complemento { get; set; }

        [Required, MaxLength(2)]
        public string Uf { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }
    }
}
