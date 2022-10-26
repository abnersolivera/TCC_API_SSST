using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Unidade_dev_net : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Unidade");
        }
    }
}
