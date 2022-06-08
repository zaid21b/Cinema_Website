using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebsite2.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_tblOrders_OrderOrederId",
                table: "tblTickets");

            migrationBuilder.DropIndex(
                name: "IX_tblTickets_OrderOrederId",
                table: "tblTickets");

            migrationBuilder.DropColumn(
                name: "OrderOrederId",
                table: "tblTickets");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "tblTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblTickets_OrderId",
                table: "tblTickets",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_tblOrders_OrderId",
                table: "tblTickets",
                column: "OrderId",
                principalTable: "tblOrders",
                principalColumn: "OrederId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_tblOrders_OrderId",
                table: "tblTickets");

            migrationBuilder.DropIndex(
                name: "IX_tblTickets_OrderId",
                table: "tblTickets");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "tblTickets");

            migrationBuilder.AddColumn<int>(
                name: "OrderOrederId",
                table: "tblTickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblTickets_OrderOrederId",
                table: "tblTickets",
                column: "OrderOrederId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_tblOrders_OrderOrederId",
                table: "tblTickets",
                column: "OrderOrederId",
                principalTable: "tblOrders",
                principalColumn: "OrederId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
