using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Acesso
{
    public class Usuario
    {
        [Key]
        public uint IdUsuario { get; set; }

        [Required, MaxLength(35), EmailAddress, JsonIgnore]
        public string Email { get; set; }

        [Required, MaxLength(30), JsonIgnore]
        public string Senha { get; set; }

        [Required, Column(TypeName = "TINYINT")]
        public byte Perfil { get; set; }

        [ForeignKey("IdCliente"), JsonIgnore]
        public Cliente.Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }
    }
}
