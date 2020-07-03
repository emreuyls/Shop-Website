using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.WebUI.Migrations
{
    public partial class adressUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress2",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "BillingPostalCode",
                table: "Adress");

            migrationBuilder.DropColumn(
                name: "BillingRegion",
                table: "Adress");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Adress",
                newName: "BillingState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BillingState",
                table: "Adress",
                newName: "PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "Adress2",
                table: "Adress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCountry",
                table: "Adress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingPostalCode",
                table: "Adress",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingRegion",
                table: "Adress",
                nullable: true);
        }
    }
}
