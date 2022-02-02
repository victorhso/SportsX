using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsX.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PFISICA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_NOME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DS_EMAIL = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DS_CLASSIFICACAO = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFISICA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PJURIDICA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_RAZAO_SOCIAL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DS_EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DS_CLASSIFICACAO = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PJURIDICA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID_ENDERECO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NR_CEP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID_ENDERECO);
                    table.ForeignKey(
                        name: "FK_ENDERECO_PFISICA_ID",
                        column: x => x.ID,
                        principalTable: "PFISICA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ENDERECO_PJURIDICA_ID",
                        column: x => x.ID,
                        principalTable: "PJURIDICA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TELEFONE",
                columns: table => new
                {
                    ID_TELEFONE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NR_TELEFONE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TELEFONE", x => x.ID_TELEFONE);
                    table.ForeignKey(
                        name: "FK_TELEFONE_PFISICA_ID",
                        column: x => x.ID,
                        principalTable: "PFISICA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TELEFONE_PJURIDICA_ID",
                        column: x => x.ID,
                        principalTable: "PJURIDICA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_ID",
                table: "ENDERECO",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TELEFONE_ID",
                table: "TELEFONE",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "TELEFONE");

            migrationBuilder.DropTable(
                name: "PFISICA");

            migrationBuilder.DropTable(
                name: "PJURIDICA");
        }
    }
}
