using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class RemoveFullNameDependency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add temporary column to store current FullName values
            migrationBuilder.AddColumn<string>(
                name: "TempFullName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            // Step 2: Copy existing FullName values into TempFullName
            migrationBuilder.Sql("UPDATE Owners SET TempFullName = FullName");

            // Step 3: Alter the FullName column to remove the computed column logic and make it nullable for now
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true,  // Temporarily allow nulls to avoid issues
                oldClrType: typeof(string),
                oldComputedColumnSql: "[FirstName] + ' ' + ISNULL([MiddleName] + ' ', '') + [LastName]");

            // Step 4: Drop the FirstName, MiddleName, and LastName columns
            migrationBuilder.DropColumn(name: "FirstName", table: "Owners");
            migrationBuilder.DropColumn(name: "MiddleName", table: "Owners");
            migrationBuilder.DropColumn(name: "LastName", table: "Owners");

            // Step 5: Copy the data back from TempFullName to FullName
            migrationBuilder.Sql("UPDATE Owners SET FullName = TempFullName");

            // Step 6: Drop the temporary TempFullName column
            migrationBuilder.DropColumn(name: "TempFullName", table: "Owners");

            // Step 7: Now, make FullName NOT NULL after ensuring no NULL values exist
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,  // Ensure it is NOT NULL after data has been populated
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Add FirstName, MiddleName, and LastName columns back
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            // Step 2: Reapply computed column logic to FullName
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[FirstName] + ' ' + ISNULL([MiddleName] + ' ', '') + [LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
