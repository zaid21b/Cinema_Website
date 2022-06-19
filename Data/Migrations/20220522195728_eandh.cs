using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class eandh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Hall_HallId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_tblMovies_MovieId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Hall_HallId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Event_EventId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hall",
                table: "Hall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Hall",
                newName: "tblHalls");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "tblEvents");

            migrationBuilder.RenameIndex(
                name: "IX_Event_MovieId",
                table: "tblEvents",
                newName: "IX_tblEvents_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_HallId",
                table: "tblEvents",
                newName: "IX_tblEvents_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblHalls",
                table: "tblHalls",
                column: "HadllId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblEvents",
                table: "tblEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_tblHalls_HallId",
                table: "Seat",
                column: "HallId",
                principalTable: "tblHalls",
                principalColumn: "HadllId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEvents_tblHalls_HallId",
                table: "tblEvents",
                column: "HallId",
                principalTable: "tblHalls",
                principalColumn: "HadllId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEvents_tblMovies_MovieId",
                table: "tblEvents",
                column: "MovieId",
                principalTable: "tblMovies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_tblEvents_EventId",
                table: "Ticket",
                column: "EventId",
                principalTable: "tblEvents",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_tblHalls_HallId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEvents_tblHalls_HallId",
                table: "tblEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEvents_tblMovies_MovieId",
                table: "tblEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_tblEvents_EventId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblHalls",
                table: "tblHalls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblEvents",
                table: "tblEvents");

            migrationBuilder.RenameTable(
                name: "tblHalls",
                newName: "Hall");

            migrationBuilder.RenameTable(
                name: "tblEvents",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_tblEvents_MovieId",
                table: "Event",
                newName: "IX_Event_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_tblEvents_HallId",
                table: "Event",
                newName: "IX_Event_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hall",
                table: "Hall",
                column: "HadllId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Hall_HallId",
                table: "Event",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "HadllId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_tblMovies_MovieId",
                table: "Event",
                column: "MovieId",
                principalTable: "tblMovies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Hall_HallId",
                table: "Seat",
                column: "HallId",
                principalTable: "Hall",
                principalColumn: "HadllId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Event_EventId",
                table: "Ticket",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
