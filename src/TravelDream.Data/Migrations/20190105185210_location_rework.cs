using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelDream.Data.Migrations
{
    public partial class location_rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAirport",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasPort",
                table: "Locations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTrainStation",
                table: "Locations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAirport",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HasPort",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HasTrainStation",
                table: "Locations");
        }
    }
}
