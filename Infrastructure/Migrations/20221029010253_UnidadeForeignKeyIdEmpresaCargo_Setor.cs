using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UnidadeForeignKeyIdEmpresaCargo_Setor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.id_Cargo);
                    table.ForeignKey(
                        name: "FK_Cargo_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
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
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.id_Setor);
                    table.ForeignKey(
                        name: "FK_Setor_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    id_Unidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    situacao_Unidade = table.Column<bool>(type: "bit", nullable: false),
                    nomeAbreviado_Unidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    razaoSocial_Unidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cnpj_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cpf_Unidade = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    inscricaoEstadual_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    inscricaoMunicipal_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cno_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dataContrato_Unidade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numeroContrato_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dataCadastro_Unidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Unidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cnae_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cnaeLivre_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cnaeSecundario_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    grauRisco_Unidade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    descricaoLocal_Unidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.id_Unidade);
                });

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
                    dataDemissao_Funcionario = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCargo = table.Column<int>(type: "int", nullable: false),
                    IdSetor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id_Funcionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "id_Cargo",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Funcionario_Setor_IdSetor",
                        column: x => x.IdSetor,
                        principalTable: "Setor",
                        principalColumn: "id_Setor",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_IdEmpresa",
                table: "Cargo",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCargo",
                table: "Funcionario",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdSetor",
                table: "Funcionario",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_Setor_IdEmpresa",
                table: "Setor",
                column: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Setor");
        }
    }
}
