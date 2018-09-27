using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoSystem.App.Migrations
{
    public partial class eav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Values_Properties_PropertyId",
                table: "Values");

            migrationBuilder.DropIndex(
                name: "IX_Values_PropertyId",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Values");

            migrationBuilder.AddColumn<int>(
                name: "ValueId",
                table: "Properties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ValueId",
                table: "Properties",
                column: "ValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Values_ValueId",
                table: "Properties",
                column: "ValueId",
                principalTable: "Values",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Values_ValueId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ValueId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ValueId",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "Values",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Values_PropertyId",
                table: "Values",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Values_Properties_PropertyId",
                table: "Values",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
