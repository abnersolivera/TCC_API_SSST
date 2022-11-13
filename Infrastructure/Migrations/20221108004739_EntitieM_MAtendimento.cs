using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class EntitieM_MAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtendimentoEmpresa",
                columns: table => new
                {
                    id_AtendimentoEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoEmpresa", x => x.id_AtendimentoEmpresa);
                    table.ForeignKey(
                        name: "FK_AtendimentoEmpresa_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "id_Atendimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoEmpresa_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoExames",
                columns: table => new
                {
                    id_AtendimentoEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdExame = table.Column<int>(type: "int", nullable: false),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false),
                    FuncionarioIdFuncionario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoExames", x => x.id_AtendimentoEmpresa);
                    table.ForeignKey(
                        name: "FK_AtendimentoExames_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "id_Atendimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoExames_Exame_IdExame",
                        column: x => x.IdExame,
                        principalTable: "Exame",
                        principalColumn: "id_Exame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoExames_Funcionario_FuncionarioIdFuncionario",
                        column: x => x.FuncionarioIdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "id_Funcionario");
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoFuncionario",
                columns: table => new
                {
                    id_AtendimentoFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoFuncionario", x => x.id_AtendimentoFuncionario);
                    table.ForeignKey(
                        name: "FK_AtendimentoFuncionario_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "id_Atendimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoFuncionario_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "id_Funcionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoRiscos",
                columns: table => new
                {
                    id_AtendimentoRiscos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRisco = table.Column<int>(type: "int", nullable: false),
                    IdAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoRiscos", x => x.id_AtendimentoRiscos);
                    table.ForeignKey(
                        name: "FK_AtendimentoRiscos_Atendimento_IdAtendimento",
                        column: x => x.IdAtendimento,
                        principalTable: "Atendimento",
                        principalColumn: "id_Atendimento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentoRiscos_Risco_IdRisco",
                        column: x => x.IdRisco,
                        principalTable: "Risco",
                        principalColumn: "id_Risco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoEmpresa_IdAtendimento",
                table: "AtendimentoEmpresa",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoEmpresa_IdEmpresa",
                table: "AtendimentoEmpresa",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoExames_FuncionarioIdFuncionario",
                table: "AtendimentoExames",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoExames_IdAtendimento",
                table: "AtendimentoExames",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoExames_IdExame",
                table: "AtendimentoExames",
                column: "IdExame");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoFuncionario_IdAtendimento",
                table: "AtendimentoFuncionario",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoFuncionario_IdFuncionario",
                table: "AtendimentoFuncionario",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoRiscos_IdAtendimento",
                table: "AtendimentoRiscos",
                column: "IdAtendimento");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoRiscos_IdRisco",
                table: "AtendimentoRiscos",
                column: "IdRisco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoEmpresa");

            migrationBuilder.DropTable(
                name: "AtendimentoExames");

            migrationBuilder.DropTable(
                name: "AtendimentoFuncionario");

            migrationBuilder.DropTable(
                name: "AtendimentoRiscos");
        }
    }
}
