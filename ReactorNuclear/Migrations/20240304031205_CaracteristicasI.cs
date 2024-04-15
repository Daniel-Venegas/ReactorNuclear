using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactorNuclear.Migrations
{
    /// <inheritdoc />
    public partial class CaracteristicasI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaracteristicasIIdCaracteristicas",
                table: "DetalleDispositivo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CaracteristicasI",
                columns: table => new
                {
                    IdCaracteristicas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaracteristicasRequired = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicasI", x => x.IdCaracteristicas);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleDispositivo_CaracteristicasIIdCaracteristicas",
                table: "DetalleDispositivo",
                column: "CaracteristicasIIdCaracteristicas");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleDispositivo_CaracteristicasI_CaracteristicasIIdCaracteristicas",
                table: "DetalleDispositivo",
                column: "CaracteristicasIIdCaracteristicas",
                principalTable: "CaracteristicasI",
                principalColumn: "IdCaracteristicas",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleDispositivo_CaracteristicasI_CaracteristicasIIdCaracteristicas",
                table: "DetalleDispositivo");

            migrationBuilder.DropTable(
                name: "CaracteristicasI");

            migrationBuilder.DropIndex(
                name: "IX_DetalleDispositivo_CaracteristicasIIdCaracteristicas",
                table: "DetalleDispositivo");

            migrationBuilder.DropColumn(
                name: "CaracteristicasIIdCaracteristicas",
                table: "DetalleDispositivo");
        }
    }
}
