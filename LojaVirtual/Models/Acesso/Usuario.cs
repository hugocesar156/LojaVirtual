using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Acesso
{
    public class Usuario
    {
        [Key]
        public uint IdUsuario { get; set; }

        [Required, MaxLength(35), EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(30)]
        public string Senha { get; set; }

        [Required, Column(TypeName = "CHAR(1)")]
        public char Perfil { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente.Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }
    }
}
