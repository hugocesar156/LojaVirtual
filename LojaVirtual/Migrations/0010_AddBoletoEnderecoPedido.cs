using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class AddBoletoEnderecoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "IdBoleto",
                table: "Pedido",
                nullable: true);

            migrationBuilder.AddColumn<uint>(
                name: "IdEnderecoPedido",
                table: "Pedido",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    IdBoleto = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataExpiracao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Url = table.Column<string>(nullable: false),
                    CodigoBarras = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleto", x => x.IdBoleto);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoPedido",
                columns: table => new
                {
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Cep = table.Column<string>(maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(maxLength: 30, nullable: false),
                    Numero = table.Column<string>(maxLength: 5, nullable: false),
                    Cidade = table.Column<string>(maxLength: 30, nullable: false),
                    Bairro = table.Column<string>(maxLength: 30, nullable: false),
                    Complemento = table.Column<string>(maxLength: 20, nullable: false),
                    Uf = table.Column<string>(maxLength: 2, nullable: false),
                    IdEnderecoPedido = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoPedido", x => x.IdEnderecoPedido);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdBoleto",
                table: "Pedido",
                column: "IdBoleto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdEnderecoPedido",
                table: "Pedido",
                column: "IdEnderecoPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Boleto_IdBoleto",
                table: "Pedido",
                column: "IdBoleto",
                principalTable: "Boleto",
                principalColumn: "IdBoleto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_EnderecoPedido_IdEnderecoPedido",
                table: "Pedido",
                column: "IdEnderecoPedido",
                principalTable: "EnderecoPedido",
                principalColumn: "IdEnderecoPedido",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Boleto_IdBoleto",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_EnderecoPedido_IdEnderecoPedido",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "EnderecoPedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdBoleto",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdEnderecoPedido",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdBoleto",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdEnderecoPedido",
                table: "Pedido");
        }
    }
}
