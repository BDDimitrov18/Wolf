using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Activity_PlotRelashionship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_PlotRelashionship_Activities_ActivityId",
                table: "Activity_PlotRelashionship");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_PlotRelashionship_Plots_PlotId",
                table: "Activity_PlotRelashionship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity_PlotRelashionship",
                table: "Activity_PlotRelashionship");

            migrationBuilder.RenameTable(
                name: "Activity_PlotRelashionship",
                newName: "Activity_PlotRelashionships");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_PlotRelashionship_PlotId",
                table: "Activity_PlotRelashionships",
                newName: "IX_Activity_PlotRelashionships_PlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity_PlotRelashionships",
                table: "Activity_PlotRelashionships",
                columns: new[] { "ActivityId", "PlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_PlotRelashionships_Activities_ActivityId",
                table: "Activity_PlotRelashionships",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_PlotRelashionships_Plots_PlotId",
                table: "Activity_PlotRelashionships",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "PlotId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_PlotRelashionships_Activities_ActivityId",
                table: "Activity_PlotRelashionships");

            migrationBuilder.DropForeignKey(
                name: "FK_Activity_PlotRelashionships_Plots_PlotId",
                table: "Activity_PlotRelashionships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity_PlotRelashionships",
                table: "Activity_PlotRelashionships");

            migrationBuilder.RenameTable(
                name: "Activity_PlotRelashionships",
                newName: "Activity_PlotRelashionship");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_PlotRelashionships_PlotId",
                table: "Activity_PlotRelashionship",
                newName: "IX_Activity_PlotRelashionship_PlotId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity_PlotRelashionship",
                table: "Activity_PlotRelashionship",
                columns: new[] { "ActivityId", "PlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_PlotRelashionship_Activities_ActivityId",
                table: "Activity_PlotRelashionship",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_PlotRelashionship_Plots_PlotId",
                table: "Activity_PlotRelashionship",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "PlotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
