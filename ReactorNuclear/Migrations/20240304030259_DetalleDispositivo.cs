using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactorNuclear.Migrations
{
    /// <inheritdoc />
    public partial class DetalleDispositivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleDispositivoIdDetalleDispositivo",
                table: "Dispositivo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DetalleDispositivo",
                columns: table => new
                {
                    IdDetalleDispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDispositivo = table.Column<int>(type: "int", nullable: false),
                    IdCaracteristicas = table.Column<int>(type: "int", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleDispositivo", x => x.IdDetalleDispositivo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispositivo_DetalleDispositivoIdDetalleDispositivo",
                table: "Dispositivo",
                column: "DetalleDispositivoIdDetalleDispositivo");

            migrationBuilder.AddForeignKey(
                name: "FK_Dispositivo_DetalleDispositivo_DetalleDispositivoIdDetalleDispositivo",
                table: "Dispositivo",
                column: "DetalleDispositivoIdDetalleDispositivo",
                principalTable: "DetalleDispositivo",
                principalColumn: "IdDetalleDispositivo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dispositivo_DetalleDispositivo_DetalleDispositivoIdDetalleDispositivo",
                table: "Dispositivo");

            migrationBuilder.DropTable(
                name: "DetalleDispositivo");

            migrationBuilder.DropIndex(
                name: "IX_Dispositivo_DetalleDispositivoIdDetalleDispositivo",
                table: "Dispositivo");

            migrationBuilder.DropColumn(
                name: "DetalleDispositivoIdDetalleDispositivo",
                table: "Dispositivo");
        }
    }
}
