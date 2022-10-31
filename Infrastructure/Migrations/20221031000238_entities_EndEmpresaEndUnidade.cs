using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class entities_EndEmpresaEndUnidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecoEmpresa",
                columns: table => new
                {
                    id_EnderecoEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoEmpresa", x => x.id_EnderecoEmpresa);
                    table.ForeignKey(
                        name: "FK_EnderecoEmpresa_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "id_Empresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoEmpresa_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "id_Endereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoUnidade",
                columns: table => new
                {
                    id_EnderecoUnidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEndereco = table.Column<int>(type: "int", nullable: false),
                    IdUnidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoUnidade", x => x.id_EnderecoUnidade);
                    table.ForeignKey(
                        name: "FK_EnderecoUnidade_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "id_Endereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnderecoUnidade_Unidade_IdUnidade",
                        column: x => x.IdUnidade,
                        principalTable: "Unidade",
                        principalColumn: "id_Unidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEmpresa_IdEmpresa",
                table: "EnderecoEmpresa",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoEmpresa_IdEndereco",
                table: "EnderecoEmpresa",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoUnidade_IdEndereco",
                table: "EnderecoUnidade",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_EnderecoUnidade_IdUnidade",
                table: "EnderecoUnidade",
                column: "IdUnidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnderecoEmpresa");

            migrationBuilder.DropTable(
                name: "EnderecoUnidade");
        }
    }
}
