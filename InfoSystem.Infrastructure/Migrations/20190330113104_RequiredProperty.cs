using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoSystem.Infrastructure.Migrations
{
    public partial class RequiredProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredAttribute",
                table: "Types",
                newName: "RequiredProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredProperty",
                table: "Types",
                newName: "RequiredAttribute");
        }
    }
}
