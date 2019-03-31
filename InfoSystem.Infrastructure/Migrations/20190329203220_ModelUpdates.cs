using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoSystem.Infrastructure.Migrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequiredAttribute",
                table: "Types",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Roles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiredAttribute",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Roles");
        }
    }
}
