using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class RiscosExames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Exame_IdPrestador",
                table: "Exame",
                column: "IdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Risco_IdPrestador",
                table: "Risco",
                column: "IdPrestador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Risco");
        }
    }
}
