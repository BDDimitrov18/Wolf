using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class StarUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StarColor",
                table: "starRequest_EmployeeRelashionships",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "#FFFF00");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StarColor",
                table: "starRequest_EmployeeRelashionships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "#FFFF00",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
