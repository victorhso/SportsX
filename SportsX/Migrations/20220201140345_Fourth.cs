using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsX.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECO_PFISICA_ID",
                table: "ENDERECO");

            migrationBuilder.DropForeignKey(
                name: "FK_ENDERECO_PJURIDICA_ID",
                table: "ENDERECO");

            migrationBuilder.DropForeignKey(
                name: "FK_TELEFONE_PFISICA_ID",
                table: "TELEFONE");

            migrationBuilder.DropForeignKey(
                name: "FK_TELEFONE_PJURIDICA_ID",
                table: "TELEFONE");

            migrationBuilder.DropIndex(
                name: "IX_TELEFONE_ID",
                table: "TELEFONE");

            migrationBuilder.DropIndex(
                name: "IX_ENDERECO_ID",
                table: "ENDERECO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_ID",
                table: "TELEFONE",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_ID",
                table: "ENDERECO",
                column: "ID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECO_PFISICA_ID",
                table: "ENDERECO",
                column: "ID",
                principalTable: "PFISICA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ENDERECO_PJURIDICA_ID",
                table: "ENDERECO",
                column: "ID",
                principalTable: "PJURIDICA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TELEFONE_PFISICA_ID",
                table: "TELEFONE",
                column: "ID",
                principalTable: "PFISICA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TELEFONE_PJURIDICA_ID",
                table: "TELEFONE",
                column: "ID",
                principalTable: "PJURIDICA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
