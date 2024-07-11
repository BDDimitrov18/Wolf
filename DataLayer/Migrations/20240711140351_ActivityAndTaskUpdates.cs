using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class ActivityAndTaskUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentTax",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "executantPayment",
                table: "Tasks",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "tax",
                table: "Tasks",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "CompletionStatus",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExecutantId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "employeePayment",
                table: "Activities",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ExecutantId",
                table: "Activities",
                column: "ExecutantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Employees_ExecutantId",
                table: "Activities",
                column: "ExecutantId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Employees_ExecutantId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ExecutantId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CommentTax",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "executantPayment",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "tax",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CompletionStatus",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ExecutantId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "employeePayment",
                table: "Activities");
        }
    }
}
