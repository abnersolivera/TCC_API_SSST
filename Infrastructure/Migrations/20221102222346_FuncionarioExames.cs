using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FuncionarioExames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuncionarioExames",
                columns: table => new
                {
                    id_FuncionarioExames = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    IdExame = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioExames", x => x.id_FuncionarioExames);
                    table.ForeignKey(
                        name: "FK_FuncionarioExames_Exame_IdExame",
                        column: x => x.IdExame,
                        principalTable: "Exame",
                        principalColumn: "id_Exame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionarioExames_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "id_Funcionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioExames_IdExame",
                table: "FuncionarioExames",
                column: "IdExame");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionarioExames_IdFuncionario",
                table: "FuncionarioExames",
                column: "IdFuncionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionarioExames");
        }
    }
}
