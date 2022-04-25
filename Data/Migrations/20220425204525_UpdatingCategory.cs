using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebsite2.Data.Migrations
{
    public partial class UpdatingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_AddingCategory_AddingCategoryId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMovies_AddingCategory_AddingCategoryId",
                table: "tblMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddingCategory",
                table: "AddingCategory");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "tblCategories");

            migrationBuilder.RenameTable(
                name: "AddingCategory",
                newName: "tblAddingCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Category_AddingCategoryId",
                table: "tblCategories",
                newName: "IX_tblCategories_AddingCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCategories",
                table: "tblCategories",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblAddingCategories",
                table: "tblAddingCategories",
                column: "AddingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCategories_tblAddingCategories_AddingCategoryId",
                table: "tblCategories",
                column: "AddingCategoryId",
                principalTable: "tblAddingCategories",
                principalColumn: "AddingCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMovies_tblAddingCategories_AddingCategoryId",
                table: "tblMovies",
                column: "AddingCategoryId",
                principalTable: "tblAddingCategories",
                principalColumn: "AddingCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCategories_tblAddingCategories_AddingCategoryId",
                table: "tblCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMovies_tblAddingCategories_AddingCategoryId",
                table: "tblMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCategories",
                table: "tblCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblAddingCategories",
                table: "tblAddingCategories");

            migrationBuilder.RenameTable(
                name: "tblCategories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "tblAddingCategories",
                newName: "AddingCategory");

            migrationBuilder.RenameIndex(
                name: "IX_tblCategories_AddingCategoryId",
                table: "Category",
                newName: "IX_Category_AddingCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddingCategory",
                table: "AddingCategory",
                column: "AddingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AddingCategory_AddingCategoryId",
                table: "Category",
                column: "AddingCategoryId",
                principalTable: "AddingCategory",
                principalColumn: "AddingCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMovies_AddingCategory_AddingCategoryId",
                table: "tblMovies",
                column: "AddingCategoryId",
                principalTable: "AddingCategory",
                principalColumn: "AddingCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
