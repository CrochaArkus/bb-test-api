using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Entities.Migrations
{
    public partial class ChallengeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id_categories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id_categories);
                });

            migrationBuilder.CreateTable(
                name: "imageUpload",
                columns: table => new
                {
                    id_image_Upload = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSubcategories = table.Column<int>(type: "int", nullable: false),
                    idCategories = table.Column<int>(type: "int", nullable: false),
                    image_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageUpload", x => x.id_image_Upload);
                });

            migrationBuilder.CreateTable(
                name: "subCategory",
                columns: table => new
                {
                    id_subcategories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categories = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategory", x => x.id_subcategories);
                    table.ForeignKey(
                        name: "FK_subCategory_category_id_categories",
                        column: x => x.id_categories,
                        principalTable: "category",
                        principalColumn: "id_categories",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subCategory_id_categories",
                table: "subCategory",
                column: "id_categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imageUpload");

            migrationBuilder.DropTable(
                name: "subCategory");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
