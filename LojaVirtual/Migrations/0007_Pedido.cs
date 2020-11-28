using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class Pedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTransacao = table.Column<uint>(nullable: false),
                    Total = table.Column<float>(type: "FLOAT", nullable: false),
                    FormaPagamento = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Situacao = table.Column<string>(type: "CHAR(1)", nullable: false),
                    IdCliente = table.Column<uint>(nullable: false),
                    IdFrete = table.Column<uint>(nullable: false),
                    IdParcelamento = table.Column<uint>(nullable: true),
                    PrazoPagamento = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Frete_IdFrete",
                        column: x => x.IdFrete,
                        principalTable: "Frete",
                        principalColumn: "IdFrete",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Parcelamento_IdParcelamento",
                        column: x => x.IdParcelamento,
                        principalTable: "Parcelamento",
                        principalColumn: "IdParcelamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoHistorico",
                columns: table => new
                {
                    IdProdutoHistorico = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Valor = table.Column<float>(type: "FLOAT", nullable: false),
                    Quantidade = table.Column<uint>(nullable: false),
                    IdPedido = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoHistorico", x => x.IdProdutoHistorico);
                    table.ForeignKey(
                        name: "FK_ProdutoHistorico_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdFrete",
                table: "Pedido",
                column: "IdFrete");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdParcelamento",
                table: "Pedido",
                column: "IdParcelamento");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoHistorico_IdPedido",
                table: "ProdutoHistorico",
                column: "IdPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoHistorico");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
