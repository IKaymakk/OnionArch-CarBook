using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    public partial class haydi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // CarReservation tablosunu oluştur
            migrationBuilder.CreateTable(
                name: "CarReservations",
                columns: table => new
                {
                    CarReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpLocationId = table.Column<int>(type: "int", nullable: false),
                    DropOffLocationId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DriverLicenseYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarReservations", x => x.CarReservationId);
                    table.ForeignKey(
                        name: "FK_CarReservations_Locations_DropOffLocationId",
                        column: x => x.DropOffLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarReservations_Locations_PickUpLocationId",
                        column: x => x.PickUpLocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            // CarReservations tablosu için indeksler oluştur
            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_DropOffLocationId",
                table: "CarReservations",
                column: "DropOffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CarReservations_PickUpLocationId",
                table: "CarReservations",
                column: "PickUpLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // CarReservation tablosunu sil
            migrationBuilder.DropTable(
                name: "CarReservations");
        }
    }
}
