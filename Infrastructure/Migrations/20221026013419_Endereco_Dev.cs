using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Endereco_Dev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
