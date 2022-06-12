using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMovies_Admin_AdminId",
                table: "tblMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "tblAdmins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblAdmins",
                table: "tblAdmins",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMovies_tblAdmins_AdminId",
                table: "tblMovies",
                column: "AdminId",
                principalTable: "tblAdmins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblMovies_tblAdmins_AdminId",
                table: "tblMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblAdmins",
                table: "tblAdmins");

            migrationBuilder.RenameTable(
                name: "tblAdmins",
                newName: "Admin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblMovies_Admin_AdminId",
                table: "tblMovies",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
