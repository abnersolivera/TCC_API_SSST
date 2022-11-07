using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class EntitieAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    id_Agendamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_Agendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hota_Agendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    compromisso_Agendamento = table.Column<int>(type: "int", nullable: false),
                    tipoCompromisso_Agendamento = table.Column<int>(type: "int", nullable: true),
                    razaoSocial_Agendamento = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    funcionario_Agendamento = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    status_Agendamento = table.Column<int>(type: "int", nullable: false),
                    dataCadastro_Agendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao_Agendamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.id_Agendamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");
        }
    }
}
