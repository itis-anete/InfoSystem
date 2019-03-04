using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InfoSystem.Infrastructure.Migrations
{
    public partial class EAVSimple : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Entities_EntityId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "EntityProperties");

            migrationBuilder.DropTable(
                name: "MarketProducts");

            migrationBuilder.DropTable(
                name: "PropertyValues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Properties_EntityId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Editable",
                table: "Entities");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Values",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "Entities",
                newName: "TypeId");

            migrationBuilder.AddColumn<int>(
                name: "AttributeId",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Values",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Properties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ValueType",
                table: "Properties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropColumn(
                name: "AttributeId",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Values");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ValueType",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Values",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Entities",
                newName: "EntityId");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Editable",
                table: "Entities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EntityProperties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EntityId = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    PropertyId = table.Column<int>(nullable: false),
                    ValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarketProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MarketId1 = table.Column<int>(nullable: true),
                    ProductId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketProducts_Markets_MarketId1",
                        column: x => x.MarketId1,
                        principalTable: "Markets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketProducts_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_EntityId",
                table: "Properties",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProducts_MarketId1",
                table: "MarketProducts",
                column: "MarketId1");

            migrationBuilder.CreateIndex(
                name: "IX_MarketProducts_ProductId1",
                table: "MarketProducts",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Entities_EntityId",
                table: "Properties",
                column: "EntityId",
                principalTable: "Entities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
