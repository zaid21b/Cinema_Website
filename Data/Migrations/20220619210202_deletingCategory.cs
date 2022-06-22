using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class deletingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMovies_tblAddingCategories_AddingCategoryId",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropTable(
                name: "tblCategories",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "tblAddingCategories",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_tblMovies_AddingCategoryId",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "AddingCategoryId",
                schema: "Identity",
                table: "tblMovies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddingCategoryId",
                schema: "Identity",
                table: "tblMovies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblAddingCategories",
                schema: "Identity",
                columns: table => new
                {
                    AddingCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAddingCategories", x => x.AddingCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tblCategories",
                schema: "Identity",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddingCategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_tblCategories_tblAddingCategories_AddingCategoryId",
                        column: x => x.AddingCategoryId,
                        principalSchema: "Identity",
                        principalTable: "tblAddingCategories",
                        principalColumn: "AddingCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblMovies_AddingCategoryId",
                schema: "Identity",
                table: "tblMovies",
                column: "AddingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategories_AddingCategoryId",
                schema: "Identity",
                table: "tblCategories",
                column: "AddingCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMovies_tblAddingCategories_AddingCategoryId",
                schema: "Identity",
                table: "tblMovies",
                column: "AddingCategoryId",
                principalSchema: "Identity",
                principalTable: "tblAddingCategories",
                principalColumn: "AddingCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
