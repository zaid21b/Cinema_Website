using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class addingTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblSeats_Ticket_TicketId",
                table: "tblSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Order_OrderId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_tblEvents_EventId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "tblTickets");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_OrderId",
                table: "tblTickets",
                newName: "IX_tblTickets_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_EventId",
                table: "tblTickets",
                newName: "IX_tblTickets_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTickets",
                table: "tblTickets",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblSeats_tblTickets_TicketId",
                table: "tblSeats",
                column: "TicketId",
                principalTable: "tblTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_Order_OrderId",
                table: "tblTickets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrederId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_tblEvents_EventId",
                table: "tblTickets",
                column: "EventId",
                principalTable: "tblEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblSeats_tblTickets_TicketId",
                table: "tblSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_Order_OrderId",
                table: "tblTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_tblEvents_EventId",
                table: "tblTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTickets",
                table: "tblTickets");

            migrationBuilder.RenameTable(
                name: "tblTickets",
                newName: "Ticket");

            migrationBuilder.RenameIndex(
                name: "IX_tblTickets_OrderId",
                table: "Ticket",
                newName: "IX_Ticket_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_tblTickets_EventId",
                table: "Ticket",
                newName: "IX_Ticket_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblSeats_Ticket_TicketId",
                table: "tblSeats",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Order_OrderId",
                table: "Ticket",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrederId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_tblEvents_EventId",
                table: "Ticket",
                column: "EventId",
                principalTable: "tblEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
