using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleStore.Migrations
{
    public partial class UpdateModelTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "RegNo",
                table: "Vehicles",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VIN",
                table: "Vehicles",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegNo",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VIN",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);
        }
    }
}
