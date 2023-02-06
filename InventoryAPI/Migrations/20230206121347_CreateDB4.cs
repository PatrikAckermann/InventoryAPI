using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Categories_CategoriesId",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Objects_CategoriesId",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Objects",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_CategoryId",
                table: "Objects",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Categories_CategoryId",
                table: "Objects",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Categories_CategoryId",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Objects_CategoryId",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Objects",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "Objects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Objects_CategoriesId",
                table: "Objects",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Categories_CategoriesId",
                table: "Objects",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
