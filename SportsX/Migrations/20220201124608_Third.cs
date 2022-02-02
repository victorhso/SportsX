using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsX.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ENDERECO",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "ENDERECO",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}
