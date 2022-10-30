using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UsuarioEmpPrestadorEmpPessoaEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PessoaEmpresa");

            migrationBuilder.DropTable(
                name: "PrestadorEmpresa");

            migrationBuilder.DropTable(
                name: "UsuarioEmpresa");
        }
    }
}
