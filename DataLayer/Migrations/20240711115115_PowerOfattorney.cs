using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class PowerOfattorney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "powerOfAttorneyDocuments",
                columns: table => new
                {
                    PowerOfAttorneyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfIssuing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_powerOfAttorneyDocuments", x => x.PowerOfAttorneyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_documentPlot_DocumentOwenerRelashionships_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "PowerOfAttorneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships",
                column: "PowerOfAttorneyId",
                principalTable: "powerOfAttorneyDocuments",
                principalColumn: "PowerOfAttorneyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_documentPlot_DocumentOwenerRelashionships_powerOfAttorneyDocuments_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropTable(
                name: "powerOfAttorneyDocuments");

            migrationBuilder.DropIndex(
                name: "IX_documentPlot_DocumentOwenerRelashionships_PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships");

            migrationBuilder.DropColumn(
                name: "PowerOfAttorneyId",
                table: "documentPlot_DocumentOwenerRelashionships");
        }
    }
}
