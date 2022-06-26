using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class deletingMovieRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieRating",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.AlterColumn<string>(
                name: "MovieImage",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieImage",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "MovieRating",
                schema: "Identity",
                table: "tblMovies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
