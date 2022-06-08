using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebsite2.Data.Migrations
{
    public partial class newMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTickets_tblOrders_OrderId",
                table: "tblTickets");

            migrationBuilder.DropTable(
                name: "tblSeats");

            migrationBuilder.DropIndex(
                name: "IX_tblTickets_OrderId",
                table: "tblTickets");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "tblTickets");

            migrationBuilder.DropColumn(
                name: "NumOfTickets",
                table: "tblOrders");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "tblTickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TicketPrice",
                table: "tblTickets",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "tblOrderTickets",
                columns: table => new
                {
                    OrderTicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderTickets", x => x.OrderTicketId);
                    table.ForeignKey(
                        name: "FK_tblOrderTickets_tblOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tblOrders",
                        principalColumn: "OrederId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrderTickets_tblTickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "tblTickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderTickets_OrderId",
                table: "tblOrderTickets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderTickets_TicketId",
                table: "tblOrderTickets",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOrderTickets");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "tblTickets");

            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "tblTickets");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "tblTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumOfTickets",
                table: "tblOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblSeats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallId = table.Column<int>(type: "int", nullable: false),
                    Screen = table.Column<int>(type: "int", nullable: false),
                    SeatT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSeats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_tblSeats_tblHalls_HallId",
                        column: x => x.HallId,
                        principalTable: "tblHalls",
                        principalColumn: "HadllId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblTickets_OrderId",
                table: "tblTickets",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSeats_HallId",
                table: "tblSeats",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTickets_tblOrders_OrderId",
                table: "tblTickets",
                column: "OrderId",
                principalTable: "tblOrders",
                principalColumn: "OrederId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
