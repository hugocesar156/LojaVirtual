using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Cliente
{
    public class EnderecoCliente : Endereco.Endereco
    {
        [Key]
        public uint IdEndereco { get; set; }

        [ForeignKey("IdCliente"), JsonIgnore]
        public Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }
    }
}
