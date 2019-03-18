using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoSystem.Infrastructure.Migrations
{
    public partial class ValueType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "Attributes",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ValueType",
                table: "Attributes",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
