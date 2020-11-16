using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Venda
{
    public class Carrinho
    {
        [Key]
        public uint IdCarrinho { get; set; }

        [Required]
        public uint Quantidade { get; set; }

        [ForeignKey("IdProduto")]
        public Produto.Produto Produto { get; set; }

        [Required]
        public uint IdProduto { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente.Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }

    }
}
