using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ChangedActivityPlotRelashionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plots_Activities_ActivityId",
                table: "Plots");

            migrationBuilder.DropIndex(
                name: "IX_Plots_ActivityId",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Plots");

            migrationBuilder.CreateTable(
                name: "Activity_PlotRelashionship",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    PlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity_PlotRelashionship", x => new { x.ActivityId, x.PlotId });
                    table.ForeignKey(
                        name: "FK_Activity_PlotRelashionship_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_PlotRelashionship_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "PlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_PlotRelashionship_PlotId",
                table: "Activity_PlotRelashionship",
                column: "PlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_PlotRelashionship");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Plots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plots_ActivityId",
                table: "Plots",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plots_Activities_ActivityId",
                table: "Plots",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
