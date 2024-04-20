using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactorNuclear.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caract",
                columns: table => new
                {
                    IdCaracteristicas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaracteristicasRequired = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caract", x => x.IdCaracteristicas);
                });

            migrationBuilder.CreateTable(
                name: "TipoV",
                columns: table => new
                {
                    IdTipoVariable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoV", x => x.IdTipoVariable);
                });

            migrationBuilder.CreateTable(
                name: "DetalleD",
                columns: table => new
                {
                    IdDetalleDispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDispositivo = table.Column<int>(type: "int", nullable: false),
                    IdCaracteristicas = table.Column<int>(type: "int", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaracteristicasIIdCaracteristicas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleD", x => x.IdDetalleDispositivo);
                    table.ForeignKey(
                        name: "FK_DetalleD_Caract_CaracteristicasIIdCaracteristicas",
                        column: x => x.CaracteristicasIIdCaracteristicas,
                        principalTable: "Caract",
                        principalColumn: "IdCaracteristicas");
                });

            migrationBuilder.CreateTable(
                name: "VarMo",
                columns: table => new
                {
                    IdVariableMonitoreo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarMonitoreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoVariable = table.Column<int>(type: "int", nullable: false),
                    TipoVariableIdTipoVariable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarMo", x => x.IdVariableMonitoreo);
                    table.ForeignKey(
                        name: "FK_VarMo_TipoV_TipoVariableIdTipoVariable",
                        column: x => x.TipoVariableIdTipoVariable,
                        principalTable: "TipoV",
                        principalColumn: "IdTipoVariable");
                });

            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    IdDispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dispo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetalleDispositivoIdDetalleDispositivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.IdDispositivo);
                    table.ForeignKey(
                        name: "FK_Dispositivo_DetalleD_DetalleDispositivoIdDetalleDispositivo",
                        column: x => x.DetalleDispositivoIdDetalleDispositivo,
                        principalTable: "DetalleD",
                        principalColumn: "IdDetalleDispositivo");
                });

            migrationBuilder.CreateTable(
                name: "monitoreoXDispos",
                columns: table => new
                {
                    IdVariableXDispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVariableMonitoreo = table.Column<int>(type: "int", nullable: false),
                    IdDispositivo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VariableMonitoreoIdVariableMonitoreo = table.Column<int>(type: "int", nullable: true),
                    DispositivoIdDispositivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monitoreoXDispos", x => x.IdVariableXDispositivo);
                    table.ForeignKey(
                        name: "FK_monitoreoXDispos_Dispositivo_DispositivoIdDispositivo",
                        column: x => x.DispositivoIdDispositivo,
                        principalTable: "Dispositivo",
                        principalColumn: "IdDispositivo");
                    table.ForeignKey(
                        name: "FK_monitoreoXDispos_VarMo_VariableMonitoreoIdVariableMonitoreo",
                        column: x => x.VariableMonitoreoIdVariableMonitoreo,
                        principalTable: "VarMo",
                        principalColumn: "IdVariableMonitoreo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleD_CaracteristicasIIdCaracteristicas",
                table: "DetalleD",
                column: "CaracteristicasIIdCaracteristicas");

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_DetalleDispositivoIdDetalleDispositivo",
                table: "Dispositivo",
                column: "DetalleDispositivoIdDetalleDispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_monitoreoXDispos_DispositivoIdDispositivo",
                table: "monitoreoXDispos",
                column: "DispositivoIdDispositivo");

            migrationBuilder.CreateIndex(
                name: "IX_monitoreoXDispos_VariableMonitoreoIdVariableMonitoreo",
                table: "monitoreoXDispos",
                column: "VariableMonitoreoIdVariableMonitoreo");

            migrationBuilder.CreateIndex(
                name: "IX_VarMo_TipoVariableIdTipoVariable",
                table: "VarMo",
                column: "TipoVariableIdTipoVariable");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "monitoreoXDispos");

            migrationBuilder.DropTable(
                name: "Dispositivo");

            migrationBuilder.DropTable(
                name: "VarMo");

            migrationBuilder.DropTable(
                name: "DetalleD");

            migrationBuilder.DropTable(
                name: "TipoV");

            migrationBuilder.DropTable(
                name: "Caract");
        }
    }
}
