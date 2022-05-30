using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebsite2.Data.Migrations
{
    public partial class editTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfTickets",
                table: "tblTickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumOfTickets",
                table: "tblTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
