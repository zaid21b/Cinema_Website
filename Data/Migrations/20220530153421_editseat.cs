using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class editseat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblSeats_tblTickets_TicketId",
                table: "tblSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_tblEvents_EventId",
                table: "tblTickets");

            migrationBuilder.DropIndex(
                name: "IX_tblSeats_TicketId",
                table: "tblSeats");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "tblSeats");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "tblTickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumOfTickets",
                table: "tblTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_tblEvents_EventId",
                table: "tblTickets",
                column: "EventId",
                principalTable: "tblEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_tblEvents_EventId",
                table: "tblTickets");

            migrationBuilder.DropColumn(
                name: "NumOfTickets",
                table: "tblTickets");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "tblTickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "tblSeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblSeats_TicketId",
                table: "tblSeats",
                column: "TicketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblSeats_tblTickets_TicketId",
                table: "tblSeats",
                column: "TicketId",
                principalTable: "tblTickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_tblEvents_EventId",
                table: "tblTickets",
                column: "EventId",
                principalTable: "tblEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
