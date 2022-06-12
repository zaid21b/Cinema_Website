using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema_Website.Data.Migrations
{
    public partial class editingRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrders_tblCustomers_CustomerId",
                schema: "Identity",
                table: "tblOrders");

            migrationBuilder.DropIndex(
                name: "IX_tblOrders_CustomerId",
                schema: "Identity",
                table: "tblOrders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "Identity",
                table: "tblOrders");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "tblOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrders_UserId",
                schema: "Identity",
                table: "tblOrders",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrders_AspNetUsers_UserId",
                schema: "Identity",
                table: "tblOrders",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrders_AspNetUsers_UserId",
                schema: "Identity",
                table: "tblOrders");

            migrationBuilder.DropIndex(
                name: "IX_tblOrders_UserId",
                schema: "Identity",
                table: "tblOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Identity",
                table: "tblOrders");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "Identity",
                table: "tblOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrders_CustomerId",
                schema: "Identity",
                table: "tblOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrders_tblCustomers_CustomerId",
                schema: "Identity",
                table: "tblOrders",
                column: "CustomerId",
                principalSchema: "Identity",
                principalTable: "tblCustomers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
