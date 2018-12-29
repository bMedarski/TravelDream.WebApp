using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelDream.Data.Migrations
{
    public partial class add_transport_designated_number : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeatsAvailable",
                table: "Transports",
                newName: "DesignationNumber");

            migrationBuilder.AddColumn<int>(
                name: "TransportId1",
                table: "Seats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_TransportId1",
                table: "Seats",
                column: "TransportId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Transports_TransportId1",
                table: "Seats",
                column: "TransportId1",
                principalTable: "Transports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Transports_TransportId1",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_TransportId1",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "TransportId1",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "DesignationNumber",
                table: "Transports",
                newName: "SeatsAvailable");
        }
    }
}
