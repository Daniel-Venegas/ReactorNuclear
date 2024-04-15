using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactorNuclear.Migrations
{
    /// <inheritdoc />
    public partial class Dispositivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DispositivoIdDispositivo",
                table: "monitoreoXDispos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Dispositivo",
                columns: table => new
                {
                    IdDispositivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dispo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositivo", x => x.IdDispositivo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_monitoreoXDispos_DispositivoIdDispositivo",
                table: "monitoreoXDispos",
                column: "DispositivoIdDispositivo");

            migrationBuilder.AddForeignKey(
                name: "FK_monitoreoXDispos_Dispositivo_DispositivoIdDispositivo",
                table: "monitoreoXDispos",
                column: "DispositivoIdDispositivo",
                principalTable: "Dispositivo",
                principalColumn: "IdDispositivo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_monitoreoXDispos_Dispositivo_DispositivoIdDispositivo",
                table: "monitoreoXDispos");

            migrationBuilder.DropTable(
                name: "Dispositivo");

            migrationBuilder.DropIndex(
                name: "IX_monitoreoXDispos_DispositivoIdDispositivo",
                table: "monitoreoXDispos");

            migrationBuilder.DropColumn(
                name: "DispositivoIdDispositivo",
                table: "monitoreoXDispos");
        }
    }
}
