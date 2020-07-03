using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.WebUI.Migrations
{
    public partial class AdressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Adress2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingAdress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingPostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BillingRegion",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipAdress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipPostalCode",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipRegion",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    Adress1 = table.Column<string>(nullable: true),
                    Adress2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    BillingAdress = table.Column<string>(nullable: true),
                    BillingCity = table.Column<string>(nullable: true),
                    BillingRegion = table.Column<string>(nullable: true),
                    BillingPostalCode = table.Column<string>(nullable: true),
                    BillingCountry = table.Column<string>(nullable: true),
                    CustomersID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adress_Customers_CustomersID",
                        column: x => x.CustomersID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adress_CustomersID",
                table: "Adress",
                column: "CustomersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.AddColumn<string>(
                name: "Adress1",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress2",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAdress",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCountry",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingPostalCode",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingRegion",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipAdress",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipPostalCode",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipRegion",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                nullable: true);
        }
    }
}
