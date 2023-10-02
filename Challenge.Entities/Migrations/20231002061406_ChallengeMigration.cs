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
                name: "content",
                columns: table => new
                {
                    id_content = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    unLocked = table.Column<bool>(type: "bit", nullable: false),
                    delete = table.Column<bool>(type: "bit", nullable: false),
                    date_create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    date_delete = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_content", x => x.id_content);
                });

            migrationBuilder.CreateTable(
                name: "imageUpload",
                columns: table => new
                {
                    id_image_Upload = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idInteriorSubcategories = table.Column<int>(type: "int", nullable: true),
                    idSubcategories = table.Column<int>(type: "int", nullable: true),
                    idCategories = table.Column<int>(type: "int", nullable: false),
                    image_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imageUpload", x => x.id_image_Upload);
                });

            migrationBuilder.CreateTable(
                name: "interiorSubCategory",
                columns: table => new
                {
                    id_interior_subcategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_catgeory = table.Column<int>(type: "int", nullable: false),
                    id_subcategory = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url_interior_Subcategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interiorSubCategory", x => x.id_interior_subcategory);
                });

            migrationBuilder.CreateTable(
                name: "magnamentContentCategory",
                columns: table => new
                {
                    id_magnament_content_categories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_content = table.Column<int>(type: "int", nullable: false),
                    id_categories = table.Column<int>(type: "int", nullable: false),
                    id_subcategories = table.Column<int>(type: "int", nullable: false),
                    id_interior_subcategories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_magnamentContentCategory", x => x.id_magnament_content_categories);
                });

            migrationBuilder.CreateTable(
                name: "subCategory",
                columns: table => new
                {
                    id_subcategories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categories = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    urlSubcategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id_categories", "active", "create_date", "name", "update_date" },
                values: new object[] { 1, true, new DateTime(2023, 10, 2, 0, 14, 5, 957, DateTimeKind.Local).AddTicks(2079), "Marketing", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id_categories", "active", "create_date", "name", "update_date" },
                values: new object[] { 2, true, new DateTime(2023, 10, 2, 0, 14, 5, 957, DateTimeKind.Local).AddTicks(2221), "Products", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_subCategory_id_categories",
                table: "subCategory",
                column: "id_categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "content");

            migrationBuilder.DropTable(
                name: "imageUpload");

            migrationBuilder.DropTable(
                name: "interiorSubCategory");

            migrationBuilder.DropTable(
                name: "magnamentContentCategory");

            migrationBuilder.DropTable(
                name: "subCategory");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
