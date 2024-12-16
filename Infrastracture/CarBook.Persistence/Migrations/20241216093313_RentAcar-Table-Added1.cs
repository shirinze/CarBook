using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RentAcarTableAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpLocationID",
                table: "RentACars");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "RentACars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "RentACars");

            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationID",
                table: "RentACars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
