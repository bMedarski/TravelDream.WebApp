using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelDream.Data.Migrations
{
    public partial class change_designation_number : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DesignationNumber",
                table: "Transports",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DesignationNumber",
                table: "Transports",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
