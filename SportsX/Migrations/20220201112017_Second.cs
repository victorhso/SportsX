using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsX.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NR_CNPJ",
                table: "PJURIDICA",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NR_CPF",
                table: "PFISICA",
                type: "VARCHAR(11)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NR_CNPJ",
                table: "PJURIDICA");

            migrationBuilder.DropColumn(
                name: "NR_CPF",
                table: "PFISICA");
        }
    }
}
