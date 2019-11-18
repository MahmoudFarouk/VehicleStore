using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleStore.Migrations
{
    public partial class CodeExceptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrorMessage = table.Column<string>(nullable: true),
                    ExceptionTime = table.Column<DateTime>(nullable: true),
                    MachineName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    AssemblyName = table.Column<string>(nullable: true),
                    AssemblyVersion = table.Column<string>(nullable: true),
                    ClassName = table.Column<string>(nullable: true),
                    MethodName = table.Column<string>(nullable: true),
                    StackDump = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeExceptions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeExceptions");
        }
    }
}
