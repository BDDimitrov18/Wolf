using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class StarColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StarColor",
                table: "starRequest_EmployeeRelashionships",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "#FFFF00");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarColor",
                table: "starRequest_EmployeeRelashionships");
        }
    }
}
