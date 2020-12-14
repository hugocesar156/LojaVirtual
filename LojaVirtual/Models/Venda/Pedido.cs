using LojaVirtual.Models.Pagamento;
using LojaVirtual.Validations;
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

        [Column(TypeName = "TINYINT"), Required]
        public byte FormaPagamento { get; set; }

        [Column(TypeName = "TINYINT"), Required]
        public byte Situacao { get; set; }

        [Column(TypeName = "DATETIME"), Required]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "DATETIME"), Required]
        public DateTime DataAtualizaco { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente.Cliente Cliente { get; set; }

        [Required]
        public uint IdCliente { get; set; }

        [ForeignKey("IdFrete")]
        public Frete Frete { get; set; }

        [Required]
        public uint IdFrete { get; set; }

        [ForeignKey("IdEnderecoPedido")]
        public EnderecoPedido Endereco { get; set; }

        [Required]
        public uint IdEnderecoPedido { get; set; }

        [ForeignKey("IdParcelamento")]
        public Parcelamento Parcelamento { get; set; }

        public uint? IdParcelamento { get; set; }

        [ForeignKey("IdBoleto")]
        public Boleto Boleto { get; set; }

        public uint? IdBoleto { get; set; }

        public List<ProdutoHistorico> Produto { get; set; }
    }

    public class ProdutoHistorico
    {
        [Key]
        public uint IdProdutoHistorico { get; set; }

        [Required]
        public uint IdProduto { get; set; }

        [Required, MaxLength(30)]
        public string Nome { get; set; }

        [Required, Column(TypeName = "FLOAT"), Range(0.01, 999999.99)]
        public float Valor { get; set; }

        [Required]
        public uint Quantidade { get; set; }

        public string CodRastreamento { get; set; }

        [Required]
        public uint IdUsuario { get; set; }

        [Column(TypeName = "TINYINT"), Required]
        public byte Situacao { get; set; }

        [Column(TypeName = "DATETIME"), Required]
        public DateTime DataAtualizacao { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }

        [Required]
        public uint IdPedido { get; set; }
    }

    public class EnderecoPedido : Endereco.Endereco
    {
        [Key]
        public uint IdEnderecoPedido { get; set; }
    }
}
