using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class entities_juste_dev_net : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    situacao_Empresa = table.Column<bool>(type: "bit", nullable: false),
                    tipoCliente_Empresa = table.Column<int>(type: "int", nullable: true),
                    nomeAbreviado_Empresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    razaoSocial_Empresa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cnpj_Empresa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cpf_Empresa = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    inscricaoEstadual_Empresa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    inscricaoMunicipal_Empresa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dataContrato_Empresa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    numeroContrato_Empresa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dataCadastro_Empresa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Empresa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id_Empresa);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id_Endereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_Endereco = table.Column<bool>(type: "bit", nullable: false),
                    tipo_Endereco = table.Column<int>(type: "int", nullable: false),
                    endereco_Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    numero_Endereco = table.Column<int>(type: "int", nullable: false),
                    complemento_Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cidade_Endereco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    estado_Endereco = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cep_Endereco = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    codigoMunicipio_Endereco = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    telefone_Endereco = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    email_Endereco = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    dataCadastro_Endereco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Endereco = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id_Endereco);
                });

            migrationBuilder.CreateTable(
                name: "Prestador",
                columns: table => new
                {
                    id_Prestador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoPrestador_Prestador = table.Column<int>(type: "int", nullable: true),
                    situcao_Prestador = table.Column<bool>(type: "bit", nullable: false),
                    tipoPessoa_Prestador = table.Column<int>(type: "int", nullable: true),
                    nome_Prestador = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    razaoSocial_Prestador = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    endereco_Prestador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    numero_Prestador = table.Column<int>(type: "int", nullable: true),
                    complemento_Prestador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cidade_Prestador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    estado_Prestador = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    cep_Prestador = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    atendente_Prestador = table.Column<bool>(type: "bit", nullable: true),
                    telefone_Prestador = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    telefoneCelular_Prestador = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    email_Prestador = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    cnpj_Prestador = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cpf_Prestador = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    dataCadastro_Prestador = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Prestador = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.id_Prestador);
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
                name: "PessoaEmpresa",
                columns: table => new
                {
                    id_PessoaEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPessoas = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaEmpresa", x => x.id_PessoaEmpresa);
                    table.ForeignKey(
                        name: "FK_PessoaEmpresa_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PessoaEmpresa_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoaEmpresa_Pessoa_IdPessoas",
                        column: x => x.IdPessoas,
                        principalTable: "Pessoa",
                        principalColumn: "id_Pessoas",
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
                    descricaoLocal_Unidade = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.id_Unidade);
                    table.ForeignKey(
                        name: "FK_Unidade_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEmpresa",
                columns: table => new
                {
                    id_UsuarioEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEmpresa", x => x.id_UsuarioEmpresa);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEmpresa_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    id_Exame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    situacao_Exame = table.Column<bool>(type: "bit", nullable: false),
                    nome_Exame = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dataCadastro_Exame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Exame = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPrestador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.id_Exame);
                    table.ForeignKey(
                        name: "FK_Exame_Prestador_IdPrestador",
                        column: x => x.IdPrestador,
                        principalTable: "Prestador",
                        principalColumn: "id_Prestador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrestadorEmpresa",
                columns: table => new
                {
                    id_PrestadorEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdPrestador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadorEmpresa", x => x.id_PrestadorEmpresa);
                    table.ForeignKey(
                        name: "FK_PrestadorEmpresa_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestadorEmpresa_Prestador_IdPrestador",
                        column: x => x.IdPrestador,
                        principalTable: "Prestador",
                        principalColumn: "id_Prestador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Risco",
                columns: table => new
                {
                    id_Risco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    situacao_Risco = table.Column<bool>(type: "bit", nullable: false),
                    nome_Risco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dataCadastro_Risco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Risco = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdPrestador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risco", x => x.id_Risco);
                    table.ForeignKey(
                        name: "FK_Risco_Prestador_IdPrestador",
                        column: x => x.IdPrestador,
                        principalTable: "Prestador",
                        principalColumn: "id_Prestador",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Exame_IdPrestador",
                table: "Exame",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdCargo",
                table: "Funcionario",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_IdSetor",
                table: "Funcionario",
                column: "IdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEmpresa_ApplicationUserId",
                table: "PessoaEmpresa",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEmpresa_IdEmpresa",
                table: "PessoaEmpresa",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_PessoaEmpresa_IdPessoas",
                table: "PessoaEmpresa",
                column: "IdPessoas");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorEmpresa_IdEmpresa",
                table: "PrestadorEmpresa",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorEmpresa_IdPrestador",
                table: "PrestadorEmpresa",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Risco_IdPrestador",
                table: "Risco",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Setor_IdEmpresa",
                table: "Setor",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Unidade_IdEmpresa",
                table: "Unidade",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_IdEmpresa",
                table: "UsuarioEmpresa",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEmpresa_IdUser",
                table: "UsuarioEmpresa",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "PessoaEmpresa");

            migrationBuilder.DropTable(
                name: "PrestadorEmpresa");

            migrationBuilder.DropTable(
                name: "Risco");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "UsuarioEmpresa");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "Prestador");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
