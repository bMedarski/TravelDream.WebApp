using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelDream.Data.Migrations
{
    public partial class SeatTransportFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Row",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "LastSeatNumber",
                table: "Transports",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSeatNumber",
                table: "Transports");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Seats",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Row",
                table: "Seats",
                nullable: true);
        }
    }
}
