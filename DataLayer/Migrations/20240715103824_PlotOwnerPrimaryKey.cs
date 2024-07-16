using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class PlotOwnerPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_documentPlot_DocumentOwenerRelashionships",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "documentPlot_DocumentOwenerRelashionships",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_documentPlot_DocumentOwenerRelashionships",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_documentPlot_DocumentOwenerRelashionships_DocumentPlotId",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "DocumentPlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_documentPlot_DocumentOwenerRelashionships",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropIndex(
                name: "IX_documentPlot_DocumentOwenerRelashionships_DocumentPlotId",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_documentPlot_DocumentOwenerRelashionships",
                table: "documentPlot_DocumentOwenerRelashionships",
                columns: new[] { "DocumentPlotId", "DocumentOwnerID" });
        }
    }
}
