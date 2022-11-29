using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class tipoPessoaEmpresaUnidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tipoPessoa_Unidade",
                table: "Unidade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoPessoa_Empresa",
                table: "Empresa",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipoPessoa_Unidade",
                table: "Unidade");

            migrationBuilder.DropColumn(
                name: "tipoPessoa_Empresa",
                table: "Empresa");
        }
    }
}
