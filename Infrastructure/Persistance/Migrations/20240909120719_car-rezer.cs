using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class carrezer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyons_CarId",
                table: "Rezervasyons",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyons_Cars_CarId",
                table: "Rezervasyons",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyons_Cars_CarId",
                table: "Rezervasyons");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyons_CarId",
                table: "Rezervasyons");
        }
    }
}
