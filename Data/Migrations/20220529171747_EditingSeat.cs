using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebsite2.Data.Migrations
{
    public partial class EditingSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatType",
                table: "tblSeats",
                newName: "SeatT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatT",
                table: "tblSeats",
                newName: "SeatType");
        }
    }
}
