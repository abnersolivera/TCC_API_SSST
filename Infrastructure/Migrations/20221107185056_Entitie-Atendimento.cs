using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class EntitieAtendimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    id_Atendimento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_Atendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAgendamento_Atendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaInicial_Atendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaFinal_Atendimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    horaAgendada_Atendimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    compromisso_Atendimento = table.Column<int>(type: "int", nullable: false),
                    tipoCompromisso_Atendimento = table.Column<int>(type: "int", nullable: false),
                    razaoSocial_Atendimento = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    funcionario_Atendimento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    rg_Atendimento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    cpf_Atendimento = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    matricula_Atendimento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    unidade_Atendimento = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    setor_Atendimento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cargo_Atendimento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    atendimento_Atendimento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdUsuarioAtendimento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status_Atendimento = table.Column<int>(type: "int", nullable: false),
                    dataCadastro_Atendimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Atendimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.id_Atendimento);
                    table.ForeignKey(
                        name: "FK_Atendimento_AspNetUsers_IdUsuarioAtendimento",
                        column: x => x.IdUsuarioAtendimento,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_IdUsuarioAtendimento",
                table: "Atendimento",
                column: "IdUsuarioAtendimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");
        }
    }
}
