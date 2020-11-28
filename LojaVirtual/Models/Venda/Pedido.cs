using LojaVirtual.Models.Pagamento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVirtual.Models.Venda
{
    public class Pedido
    {
        [Key]
        public uint IdPedido { get; set; }

        [Required]
        public uint IdTransacao { get; set; }

        [Column(TypeName = "FLOAT"), Required]
        public float Total { get; set; }

        [Column(TypeName = "CHAR(1)"), Required]
        public char FormaPagamento { get; set; }

        [Column(TypeName = "CHAR(1)"), Required]
        public char Situacao { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente.Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }

        [ForeignKey("IdFrete")]
        public Frete Frete { get; set; }

        [Required]
        public uint IdFrete { get; set; }

        [ForeignKey("IdParcelamento")]
        public Parcelamento Parcelamento { get; set; }

        public uint? IdParcelamento { get; set; }

        [Column(TypeName = "DATETIME")] 
        public DateTime? PrazoPagamento { get; set; }

        [Column(TypeName = "DATETIME"), Required]
        public DateTime DataCriacao { get; set; }

        public List<ProdutoHistorico> Produto { get; set; }
    }

    public class ProdutoHistorico
    {
        [Key]
        public uint IdProdutoHistorico { get; set; }

        [Required, MaxLength(30)]
        public string Nome { get; set; }

        [Required, Column(TypeName = "FLOAT"), Range(0.01, 999999.99)]
        public float Valor { get; set; }

        [Required]
        public uint Quantidade { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        [Required]
        public uint IdPedido { get; set; }
    }
}
