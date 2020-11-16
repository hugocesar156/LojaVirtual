using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Models.Cliente
{
    public class Cliente
    {
        [Key]
        public uint IdCliente { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Required, MaxLength(11), MinLength(11)]
        public string Cpf { get; set; }
    }
}
