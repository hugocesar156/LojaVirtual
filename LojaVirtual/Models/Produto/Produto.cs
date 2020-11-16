using LojaVirtual.Models.Acesso;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Produto
{
    public class Produto
    {
        [Key]
        public uint IdProduto { get; set; }

        [Required, MaxLength(30)]
        public string Nome { get; set; }

        [Required, MaxLength(150)]
        public string Descricao { get; set; }

        [Required, Column(TypeName = "FLOAT"), Range(0.01, 999999.99)]
        public float Valor { get; set; }

        [Required, Range(1, 9999)]
        public uint Estoque { get; set; }

        [Required, MaxLength(25)]
        public string Fabricante { get; set; }

        [Required, MaxLength(25)]
        public string Modelo { get; set; }

        [Required, MaxLength(20)]
        public string Cor { get; set; }

        [Required, Column(TypeName = "FLOAT"), Range(0.001, 30)]
        public float Peso { get; set; }

        [Required, Range(2, 105)]
        public uint Altura { get; set; }

        [Required, Range(16, 105)]
        public uint Comprimento { get; set; }

        [Required, Range(11, 105)]
        public uint Largura { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [Required]
        public uint IdUsuario { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        [Required]
        public uint IdCategoria { get; set; }

        public List<Imagem> Imagem { get; set; }
    }

    public class Categoria
    {
        [Key]
        public uint IdCategoria { get; set; }

        [Required, MaxLength(20)]
        public string Nome { get; set; }

        [ForeignKey("CategoriaPaiId")]
        public Categoria CategoriaPai { get; set; }

        public uint? CategoriaPaiId { get; set; }
    }

    public class Imagem
    {
        [Key]
        public uint IdImagem { get; set; }

        [Required, MaxLength(150)]
        public string Caminho { get; set; }

        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }

        [Required]
        public uint IdProduto { get; set; }
    }
}
