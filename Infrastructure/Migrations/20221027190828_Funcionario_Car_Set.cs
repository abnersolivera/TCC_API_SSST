using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Funcionario_Car_Set : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id_Funcionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    situacao_Funcionario = table.Column<bool>(type: "bit", nullable: false),
                    nome_Funcionario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dataNascimento_Funcionario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cpf_Funcionario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    rg_Funcionario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    pis_Funcionario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    telefone_Funcionario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email_Funcionario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    sexo_Funcionario = table.Column<int>(type: "int", nullable: false),
                    dataCadastro_Funcionario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Funcionario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAdmissao_Funcionario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataDemissao_Funcionario = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id_Funcionario);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    id_Cargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    situacao_Cargo = table.Column<bool>(type: "bit", nullable: false),
                    nome_Cargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricao_Cargo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dataCadastro_Cargo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Cargo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.id_Cargo);
                    table.ForeignKey(
                        name: "FK_Cargo_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "id_Funcionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    id_Setor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    situacao_Setor = table.Column<bool>(type: "bit", nullable: false),
                    nome_Setor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descricao_Setor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dataCadastro_Setor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Setor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.id_Setor);
                    table.ForeignKey(
                        name: "FK_Setor_Funcionario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "id_Funcionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_IdFuncionario",
                table: "Cargo",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Setor_IdFuncionario",
                table: "Setor",
                column: "IdFuncionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
