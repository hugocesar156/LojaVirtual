using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class AlteraSituacaoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Pedido");

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "ProdutoHistorico",
                type: "CHAR(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "ProdutoHistorico");

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "Pedido",
                type: "CHAR(1)",
                nullable: false,
                defaultValue: "");
        }
    }
}
