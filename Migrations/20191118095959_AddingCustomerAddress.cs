using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleStore.Migrations
{
    public partial class AddingCustomerAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(128)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(256)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldNullable: true);
        }
    }
}
