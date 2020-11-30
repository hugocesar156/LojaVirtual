using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Models.Endereco
{
    public abstract class Endereco
    {
        [Required, MaxLength(20)]
        public string Nome { get; set; }

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
    }
}
