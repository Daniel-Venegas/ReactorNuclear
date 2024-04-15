using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactorNuclear.Migrations
{
    /// <inheritdoc />
    public partial class TipoVariable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoVariableIdTipoVariable",
                table: "VariableMonitoreo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoVariable",
                columns: table => new
                {
                    IdTipoVariable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variable = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVariable", x => x.IdTipoVariable);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariableMonitoreo_TipoVariableIdTipoVariable",
                table: "VariableMonitoreo",
                column: "TipoVariableIdTipoVariable");

            migrationBuilder.AddForeignKey(
                name: "FK_VariableMonitoreo_TipoVariable_TipoVariableIdTipoVariable",
                table: "VariableMonitoreo",
                column: "TipoVariableIdTipoVariable",
                principalTable: "TipoVariable",
                principalColumn: "IdTipoVariable",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariableMonitoreo_TipoVariable_TipoVariableIdTipoVariable",
                table: "VariableMonitoreo");

            migrationBuilder.DropTable(
                name: "TipoVariable");

            migrationBuilder.DropIndex(
                name: "IX_VariableMonitoreo_TipoVariableIdTipoVariable",
                table: "VariableMonitoreo");

            migrationBuilder.DropColumn(
                name: "TipoVariableIdTipoVariable",
                table: "VariableMonitoreo");
        }
    }
}
