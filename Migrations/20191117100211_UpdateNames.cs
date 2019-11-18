using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleStore.Migrations
{
    public partial class UpdateNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleName",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "VehicleName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
