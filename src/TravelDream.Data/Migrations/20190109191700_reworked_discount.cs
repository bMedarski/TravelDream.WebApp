using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelDream.Data.Migrations
{
    public partial class reworked_discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Discounts_DiscountId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_DiscountId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Tickets");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Tickets",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DiscountId",
                table: "Tickets",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Discounts_DiscountId",
                table: "Tickets",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
