using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.WebUI.Migrations
{
    public partial class AdressTableNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdressTitle",
                table: "Adress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Names",
                table: "Adress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Adress",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdressTitle",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Adress");
        }
    }
}
