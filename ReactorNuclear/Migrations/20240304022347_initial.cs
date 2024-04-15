using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactorNuclear.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "monitoreoXDispos",
                columns: table => new
                {
                    IdVariableXDispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVariableMonitoreo = table.Column<int>(type: "int", nullable: false),
                    IdDispositivo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monitoreoXDispos", x => x.IdVariableXDispositivo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "monitoreoXDispos");
        }
    }
}
