using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class dev_prestador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestador");
        }
    }
}
