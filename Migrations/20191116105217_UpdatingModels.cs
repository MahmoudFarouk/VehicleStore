using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleStore.Migrations
{
    public partial class UpdatingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vehicles");

            migrationBuilder.AddColumn<bool>(
                name: "IsConnected",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConnected",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
