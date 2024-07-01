using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class AddparentActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentActivityId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ParentActivityId",
                table: "Activities",
                column: "ParentActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Activities_ParentActivityId",
                table: "Activities",
                column: "ParentActivityId",
                principalTable: "Activities",
                principalColumn: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_ParentActivityId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ParentActivityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ParentActivityId",
                table: "Activities");
        }
    }
}
