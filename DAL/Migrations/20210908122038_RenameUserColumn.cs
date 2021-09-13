using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RenameUserColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Users",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
