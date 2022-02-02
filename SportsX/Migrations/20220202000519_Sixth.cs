using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsX.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "TELEFONE");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ENDERECO");

            migrationBuilder.AddColumn<int>(
                name: "ID_PF",
                table: "TELEFONE",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_PJ",
                table: "TELEFONE",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_PF",
                table: "ENDERECO",
                type: "INT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ID_PJ",
                table: "ENDERECO",
                type: "INT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID_PF",
                table: "TELEFONE");

            migrationBuilder.DropColumn(
                name: "ID_PJ",
                table: "TELEFONE");

            migrationBuilder.DropColumn(
                name: "ID_PF",
                table: "ENDERECO");

            migrationBuilder.DropColumn(
                name: "ID_PJ",
                table: "ENDERECO");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "TELEFONE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ENDERECO",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }
    }
}
