using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddingCategory",
                columns: table => new
                {
                    AddingCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddingCategory", x => x.AddingCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Hall",
                columns: table => new
                {
                    HadllId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hall", x => x.HadllId);
                });

            migrationBuilder.CreateTable(
                name: "ViewingMovie",
                columns: table => new
                {
                    ViewingMovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewingMovie", x => x.ViewingMovieId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddingCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_AddingCategory_AddingCategoryId",
                        column: x => x.AddingCategoryId,
                        principalTable: "AddingCategory",
                        principalColumn: "AddingCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewingMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_tblCustomers_ViewingMovie_ViewingMovieId",
                        column: x => x.ViewingMovieId,
                        principalTable: "ViewingMovie",
                        principalColumn: "ViewingMovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MovieTrailer = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    AddingCategoryId = table.Column<int>(type: "int", nullable: true),
                    ViewingMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMovies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_tblMovies_AddingCategory_AddingCategoryId",
                        column: x => x.AddingCategoryId,
                        principalTable: "AddingCategory",
                        principalColumn: "AddingCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMovies_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMovies_ViewingMovie_ViewingMovieId",
                        column: x => x.ViewingMovieId,
                        principalTable: "ViewingMovie",
                        principalColumn: "ViewingMovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrederId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrederId);
                    table.ForeignKey(
                        name: "FK_Order_tblCustomers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "tblCustomers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Hall_HallId",
                        column: x => x.HallId,
                        principalTable: "Hall",
                        principalColumn: "HadllId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_tblMovies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "tblMovies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ticket_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrederId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatType = table.Column<int>(type: "int", nullable: false),
                    Screen = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seat_Hall_HallId",
                        column: x => x.HallId,
                        principalTable: "Hall",
                        principalColumn: "HadllId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seat_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_AddingCategoryId",
                table: "Category",
                column: "AddingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_HallId",
                table: "Event",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_MovieId",
                table: "Event",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_HallId",
                table: "Seat",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TicketId",
                table: "Seat",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCustomers_ViewingMovieId",
                table: "tblCustomers",
                column: "ViewingMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovies_AddingCategoryId",
                table: "tblMovies",
                column: "AddingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovies_AdminId",
                table: "tblMovies",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMovies_ViewingMovieId",
                table: "tblMovies",
                column: "ViewingMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EventId",
                table: "Ticket",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderId",
                table: "Ticket",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Hall");

            migrationBuilder.DropTable(
                name: "tblMovies");

            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DropTable(
                name: "AddingCategory");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "ViewingMovie");
        }
    }
}
