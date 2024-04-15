using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactorNuclear.Migrations
{
    /// <inheritdoc />
    public partial class VariableMonitoreo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VariableMonitoreoIdVariableMonitoreo",
                table: "monitoreoXDispos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VariableMonitoreo",
                columns: table => new
                {
                    IdVariableMonitoreo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarMonitoreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoVarible = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableMonitoreo", x => x.IdVariableMonitoreo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_monitoreoXDispos_VariableMonitoreoIdVariableMonitoreo",
                table: "monitoreoXDispos",
                column: "VariableMonitoreoIdVariableMonitoreo");

            migrationBuilder.AddForeignKey(
                name: "FK_monitoreoXDispos_VariableMonitoreo_VariableMonitoreoIdVariableMonitoreo",
                table: "monitoreoXDispos",
                column: "VariableMonitoreoIdVariableMonitoreo",
                principalTable: "VariableMonitoreo",
                principalColumn: "IdVariableMonitoreo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_monitoreoXDispos_VariableMonitoreo_VariableMonitoreoIdVariableMonitoreo",
                table: "monitoreoXDispos");

            migrationBuilder.DropTable(
                name: "VariableMonitoreo");

            migrationBuilder.DropIndex(
                name: "IX_monitoreoXDispos_VariableMonitoreoIdVariableMonitoreo",
                table: "monitoreoXDispos");

            migrationBuilder.DropColumn(
                name: "VariableMonitoreoIdVariableMonitoreo",
                table: "monitoreoXDispos");
        }
    }
}
