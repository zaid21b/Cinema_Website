using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebsite2.Data.Migrations
{
    public partial class addingOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_tblCustomers_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_Order_OrderId",
                table: "tblTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "tblOrders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "tblOrders",
                newName: "IX_tblOrders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOrders",
                table: "tblOrders",
                column: "OrederId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrders_tblCustomers_CustomerId",
                table: "tblOrders",
                column: "CustomerId",
                principalTable: "tblCustomers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_tblOrders_tblCustomers_CustomerId",
                table: "tblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_tblOrders_OrderId",
                table: "tblTickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOrders",
                table: "tblOrders");

            migrationBuilder.RenameTable(
                name: "tblOrders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_tblOrders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrederId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_tblCustomers_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "tblCustomers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_Order_OrderId",
                table: "tblTickets",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrederId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
