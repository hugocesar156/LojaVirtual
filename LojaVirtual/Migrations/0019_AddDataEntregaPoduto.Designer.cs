﻿// <auto-generated />
using System;
using LojaVirtual.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LojaVirtual.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201221184847_AddDataEntregaPoduto")]
    partial class AddDataEntregaPoduto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LojaVirtual.Models.Acesso.Usuario", b =>
                {
                    b.Property<uint>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<uint>("IdCliente");

                    b.Property<sbyte>("Perfil")
                        .HasColumnType("TINYINT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdCliente");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("LojaVirtual.Models.Cliente.Cliente", b =>
                {
                    b.Property<uint>("IdCliente")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("LojaVirtual.Models.Cliente.ContatoCliente", b =>
                {
                    b.Property<uint>("IdContato")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("IdCliente");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Numero")
                        .IsRequired();

                    b.HasKey("IdContato");

                    b.HasIndex("IdCliente");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("LojaVirtual.Models.Cliente.EnderecoCliente", b =>
                {
                    b.Property<uint>("IdEndereco")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<uint>("IdCliente");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("IdEndereco");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("LojaVirtual.Models.Pagamento.Boleto", b =>
                {
                    b.Property<uint>("IdBoleto")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoBarras")
                        .IsRequired();

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("IdBoleto");

                    b.ToTable("Boleto");
                });

            modelBuilder.Entity("LojaVirtual.Models.Pagamento.Parcelamento", b =>
                {
                    b.Property<uint>("IdParcelamento")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Juros");

                    b.Property<byte>("Parcelas");

                    b.Property<float>("ValorParcela")
                        .HasColumnType("FLOAT");

                    b.Property<float>("ValorTotal")
                        .HasColumnType("FLOAT");

                    b.HasKey("IdParcelamento");

                    b.ToTable("Parcelamento");
                });

            modelBuilder.Entity("LojaVirtual.Models.Produto.Categoria", b =>
                {
                    b.Property<uint>("IdCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<uint?>("CategoriaPaiId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("IdCategoria");

                    b.HasIndex("CategoriaPaiId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("LojaVirtual.Models.Produto.Imagem", b =>
                {
                    b.Property<uint>("IdImagem")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caminho")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<uint>("IdProduto");

                    b.HasKey("IdImagem");

                    b.HasIndex("IdProduto");

                    b.ToTable("Imagem");
                });

            modelBuilder.Entity("LojaVirtual.Models.Produto.Produto", b =>
                {
                    b.Property<uint>("IdProduto")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("Altura");

                    b.Property<uint>("Comprimento");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<uint>("Estoque");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<uint>("IdCategoria");

                    b.Property<uint>("IdUsuario");

                    b.Property<uint>("Largura");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<float>("Peso")
                        .HasColumnType("FLOAT");

                    b.Property<float>("Valor")
                        .HasColumnType("FLOAT");

                    b.HasKey("IdProduto");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.Carrinho", b =>
                {
                    b.Property<uint>("IdCarrinho")
                        .ValueGeneratedOnAdd();

                    b.Property<uint>("IdCliente");

                    b.Property<uint>("IdProduto");

                    b.Property<uint>("Quantidade");

                    b.HasKey("IdCarrinho");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdProduto");

                    b.ToTable("Carrinho");
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.EnderecoPedido", b =>
                {
                    b.Property<uint>("IdEnderecoPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("IdEnderecoPedido");

                    b.ToTable("EnderecoPedido");
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.Frete", b =>
                {
                    b.Property<uint>("IdFrete")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("DiasEntrega");

                    b.Property<DateTime>("Prazo")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Servico")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)))
                        .HasColumnType("CHAR(1)");

                    b.Property<float>("Valor")
                        .HasColumnType("FLOAT");

                    b.HasKey("IdFrete");

                    b.ToTable("Frete");
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.Pedido", b =>
                {
                    b.Property<uint>("IdPedido")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<sbyte>("FormaPagamento")
                        .HasColumnType("TINYINT");

                    b.Property<uint?>("IdBoleto");

                    b.Property<uint>("IdCliente");

                    b.Property<uint>("IdEnderecoPedido");

                    b.Property<uint>("IdFrete");

                    b.Property<uint?>("IdParcelamento");

                    b.Property<uint>("IdTransacao");

                    b.Property<sbyte>("Situacao")
                        .HasColumnType("TINYINT");

                    b.Property<float>("Total")
                        .HasColumnType("FLOAT");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdBoleto");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEnderecoPedido");

                    b.HasIndex("IdFrete");

                    b.HasIndex("IdParcelamento");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.ProdutoHistorico", b =>
                {
                    b.Property<uint>("IdProdutoHistorico")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodRastreamento")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("DATETIME");

                    b.Property<uint>("IdPedido");

                    b.Property<uint>("IdProduto");

                    b.Property<uint>("IdUsuario");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("PrazoEntrega")
                        .HasColumnType("DATETIME");

                    b.Property<uint>("Quantidade");

                    b.Property<sbyte>("Situacao")
                        .HasColumnType("TINYINT");

                    b.Property<float>("Valor")
                        .HasColumnType("FLOAT");

                    b.HasKey("IdProdutoHistorico");

                    b.HasIndex("IdPedido");

                    b.ToTable("ProdutoHistorico");
                });

            modelBuilder.Entity("LojaVirtual.Models.Acesso.Usuario", b =>
                {
                    b.HasOne("LojaVirtual.Models.Cliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaVirtual.Models.Cliente.ContatoCliente", b =>
                {
                    b.HasOne("LojaVirtual.Models.Cliente.Cliente", "Cliente")
                        .WithMany("Contato")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaVirtual.Models.Cliente.EnderecoCliente", b =>
                {
                    b.HasOne("LojaVirtual.Models.Cliente.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("LojaVirtual.Models.Cliente.EnderecoCliente", "IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaVirtual.Models.Produto.Categoria", b =>
                {
                    b.HasOne("LojaVirtual.Models.Produto.Categoria", "CategoriaPai")
                        .WithMany()
                        .HasForeignKey("CategoriaPaiId");
                });

            modelBuilder.Entity("LojaVirtual.Models.Produto.Imagem", b =>
                {
                    b.HasOne("LojaVirtual.Models.Produto.Produto", "Produto")
                        .WithMany("Imagem")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaVirtual.Models.Produto.Produto", b =>
                {
                    b.HasOne("LojaVirtual.Models.Produto.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaVirtual.Models.Acesso.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.Carrinho", b =>
                {
                    b.HasOne("LojaVirtual.Models.Cliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaVirtual.Models.Produto.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.Pedido", b =>
                {
                    b.HasOne("LojaVirtual.Models.Pagamento.Boleto", "Boleto")
                        .WithMany()
                        .HasForeignKey("IdBoleto");

                    b.HasOne("LojaVirtual.Models.Cliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaVirtual.Models.Venda.EnderecoPedido", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEnderecoPedido")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaVirtual.Models.Venda.Frete", "Frete")
                        .WithMany()
                        .HasForeignKey("IdFrete")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LojaVirtual.Models.Pagamento.Parcelamento", "Parcelamento")
                        .WithMany()
                        .HasForeignKey("IdParcelamento");
                });

            modelBuilder.Entity("LojaVirtual.Models.Venda.ProdutoHistorico", b =>
                {
                    b.HasOne("LojaVirtual.Models.Venda.Pedido", "Pedido")
                        .WithMany("Produto")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
