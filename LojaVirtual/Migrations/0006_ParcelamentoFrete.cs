using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class ParcelamentoFrete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoIbge",
                table: "Endereco");

            migrationBuilder.CreateTable(
                name: "Frete",
                columns: table => new
                {
                    IdFrete = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<float>(type: "FLOAT", nullable: false),
                    Prazo = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Servico = table.Column<string>(type: "CHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frete", x => x.IdFrete);
                });

            migrationBuilder.CreateTable(
                name: "Parcelamento",
                columns: table => new
                {
                    IdParcelamento = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Parcelas = table.Column<byte>(nullable: false),
                    ValorParcela = table.Column<float>(type: "FLOAT", nullable: false),
                    ValorTotal = table.Column<float>(type: "FLOAT", nullable: false),
                    Juros = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcelamento", x => x.IdParcelamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frete");

            migrationBuilder.DropTable(
                name: "Parcelamento");

            migrationBuilder.AddColumn<string>(
                name: "CodigoIbge",
                table: "Endereco",
                maxLength: 7,
                nullable: false,
                defaultValue: "");
        }
    }
}
