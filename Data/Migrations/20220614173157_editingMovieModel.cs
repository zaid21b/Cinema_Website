using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class editingMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMovies_tblAdmins_AdminId",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMovies_ViewingMovie_ViewingMovieId",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropTable(
                name: "tblAdmins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "tblCustomers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ViewingMovie",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_tblMovies_AdminId",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropIndex(
                name: "IX_tblMovies_ViewingMovieId",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "ViewingMovieId",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                schema: "Identity",
                table: "tblMovies",
                newName: "MMPARating");

            migrationBuilder.AlterColumn<string>(
                name: "MovieTrailer",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "MovieDescription",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Generes",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MovieRating",
                schema: "Identity",
                table: "tblMovies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                schema: "Identity",
                table: "tblMovies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RunTime",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Generes",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "MovieRating",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.DropColumn(
                name: "RunTime",
                schema: "Identity",
                table: "tblMovies");

            migrationBuilder.RenameColumn(
                name: "MMPARating",
                schema: "Identity",
                table: "tblMovies",
                newName: "AdminId");

            migrationBuilder.AlterColumn<string>(
                name: "MovieTrailer",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MovieImage",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MovieDescription",
                schema: "Identity",
                table: "tblMovies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ViewingMovieId",
                schema: "Identity",
                table: "tblMovies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblAdmins",
                schema: "Identity",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAdmins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "ViewingMovie",
                schema: "Identity",
                columns: table => new
                {
                    ViewingMovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewingMovie", x => x.ViewingMovieId);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                schema: "Identity",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewingMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_tblCustomers_ViewingMovie_ViewingMovieId",
                        column: x => x.ViewingMovieId,
                        principalSchema: "Identity",
                        principalTable: "ViewingMovie",
                        principalColumn: "ViewingMovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblMovies_AdminId",
                schema: "Identity",
                table: "tblMovies",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovies_ViewingMovieId",
                schema: "Identity",
                table: "tblMovies",
                column: "ViewingMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomers_ViewingMovieId",
                schema: "Identity",
                table: "tblCustomers",
                column: "ViewingMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMovies_tblAdmins_AdminId",
                schema: "Identity",
                table: "tblMovies",
                column: "AdminId",
                principalSchema: "Identity",
                principalTable: "tblAdmins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMovies_ViewingMovie_ViewingMovieId",
                schema: "Identity",
                table: "tblMovies",
                column: "ViewingMovieId",
                principalSchema: "Identity",
                principalTable: "ViewingMovie",
                principalColumn: "ViewingMovieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
