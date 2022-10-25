using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Empresa : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
