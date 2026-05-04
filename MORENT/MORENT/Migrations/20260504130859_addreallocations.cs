using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MORENT.Migrations
{
    /// <inheritdoc />
    public partial class addreallocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DropoffLat",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DropoffLng",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PickupLat",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PickupLng",
                table: "Bookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropoffLat",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DropoffLng",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PickupLat",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PickupLng",
                table: "Bookings");
        }
    }
}
