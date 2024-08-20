using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class RequestOwnerUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestCreatorId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[FirstName] + ' ' + ISNULL([MiddleName] + ' ', '') + [LastName]");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestCreatorId",
                table: "Requests",
                column: "RequestCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Employees_RequestCreatorId",
                table: "Requests",
                column: "RequestCreatorId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Employees_RequestCreatorId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestCreatorId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "RequestCreatorId",
                table: "Requests");
        }
    }
}
