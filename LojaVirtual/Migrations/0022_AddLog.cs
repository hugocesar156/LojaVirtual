using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LojaVirtual.Migrations
{
    public partial class AddLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<string>(maxLength: 100, nullable: true),
                    Level = table.Column<string>(maxLength: 15, nullable: true),
                    Template = table.Column<string>(maxLength: 100, nullable: true),
                    Message = table.Column<string>(maxLength: 50, nullable: true),
                    Exception = table.Column<string>(maxLength: 100, nullable: true),
                    Properties = table.Column<string>(maxLength: 150, nullable: true),
                    _ts = table.Column<TimeSpan>(type: "TIMESTAMP", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
