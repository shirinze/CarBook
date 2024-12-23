using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_Location_Reservation_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_PickUpLocationId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PickUpLocationId",
                table: "Reservations",
                newName: "PickUpLocationID");

            migrationBuilder.RenameColumn(
                name: "DropOffLocationId",
                table: "Reservations",
                newName: "DropOffLocationID");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Reservations",
                newName: "CarID");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PickUpLocationId",
                table: "Reservations",
                newName: "IX_Reservations_PickUpLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DropOffLocationId",
                table: "Reservations",
                newName: "IX_Reservations_DropOffLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarID",
                table: "Reservations",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "CarID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationID",
                table: "Reservations",
                column: "DropOffLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_PickUpLocationID",
                table: "Reservations",
                column: "PickUpLocationID",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_PickUpLocationID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarID",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "PickUpLocationID",
                table: "Reservations",
                newName: "PickUpLocationId");

            migrationBuilder.RenameColumn(
                name: "DropOffLocationID",
                table: "Reservations",
                newName: "DropOffLocationId");

            migrationBuilder.RenameColumn(
                name: "CarID",
                table: "Reservations",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Reservations",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_PickUpLocationID",
                table: "Reservations",
                newName: "IX_Reservations_PickUpLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_DropOffLocationID",
                table: "Reservations",
                newName: "IX_Reservations_DropOffLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_DropOffLocationId",
                table: "Reservations",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_PickUpLocationId",
                table: "Reservations",
                column: "PickUpLocationId",
                principalTable: "Locations",
                principalColumn: "LocationID");
        }
    }
}
