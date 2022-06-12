using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class addingSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_tblHalls_HallId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Ticket_TicketId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "tblSeats");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_TicketId",
                table: "tblSeats",
                newName: "IX_tblSeats_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_HallId",
                table: "tblSeats",
                newName: "IX_tblSeats_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblSeats",
                table: "tblSeats",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblSeats_tblHalls_HallId",
                table: "tblSeats",
                column: "HallId",
                principalTable: "tblHalls",
                principalColumn: "HadllId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblSeats_Ticket_TicketId",
                table: "tblSeats",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblSeats_tblHalls_HallId",
                table: "tblSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_tblSeats_Ticket_TicketId",
                table: "tblSeats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblSeats",
                table: "tblSeats");

            migrationBuilder.RenameTable(
                name: "tblSeats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_tblSeats_TicketId",
                table: "Seat",
                newName: "IX_Seat_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_tblSeats_HallId",
                table: "Seat",
                newName: "IX_Seat_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_tblHalls_HallId",
                table: "Seat",
                column: "HallId",
                principalTable: "tblHalls",
                principalColumn: "HadllId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Ticket_TicketId",
                table: "Seat",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
