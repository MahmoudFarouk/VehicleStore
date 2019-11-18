using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleStore.Migrations
{
    public partial class CreateVSDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VehicleName",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleName",
                table: "Vehicles");
        }
    }
}
