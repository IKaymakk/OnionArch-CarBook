using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class migxyzadn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // AppUserId sütununu nullable olarak ekleyin
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Rezervasyons",
                type: "int",
                nullable: true); // Nullable olarak ekleniyor

            // Yabancı anahtar kısıtlamasını ekleyin
            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyons_AppUsers_AppUserId",
                table: "Rezervasyons",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Yabancı anahtar kısıtlamasını kaldırın
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyons_AppUsers_AppUserId",
                table: "Rezervasyons");

            // Sütunu kaldırın
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Rezervasyons");
        }
    }
}
