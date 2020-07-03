using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.WebUI.Migrations
{
    public partial class AddGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Customers");
        }
    }
}
