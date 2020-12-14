using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class AlteraTipoSituacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "Perfil",
                table: "Usuario",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Situacao",
                table: "ProdutoHistorico",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Situacao",
                table: "Pedido",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");

            migrationBuilder.AlterColumn<sbyte>(
                name: "FormaPagamento",
                table: "Pedido",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Perfil",
                table: "Usuario",
                type: "CHAR(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "ProdutoHistorico",
                type: "CHAR(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "Pedido",
                type: "CHAR(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "TINYINT");

            migrationBuilder.AlterColumn<string>(
                name: "FormaPagamento",
                table: "Pedido",
                type: "CHAR(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "TINYINT");
        }
    }
}
