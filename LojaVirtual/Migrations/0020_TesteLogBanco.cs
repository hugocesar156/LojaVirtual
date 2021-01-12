using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class TesteLogBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropColumn(
                name: "Prazo",
                table: "Frete");

            migrationBuilder.AlterColumn<sbyte>(
                name: "DiasEntrega",
                table: "Frete",
                type: "TINYINT",
                nullable: false,
                oldClrType: typeof(TimeSpan));*/

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(maxLength: 50, nullable: true),
                    MessageTemplate = table.Column<string>(maxLength: 50, nullable: true),
                    TimeSpan = table.Column<TimeSpan>(nullable: false),
                    Exception = table.Column<string>(maxLength: 50, nullable: true),
                    Properties = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            /*migrationBuilder.AlterColumn<TimeSpan>(
                name: "DiasEntrega",
                table: "Frete",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "TINYINT");

            migrationBuilder.AddColumn<DateTime>(
                name: "Prazo",
                table: "Frete",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));*/
        }
    }
}
