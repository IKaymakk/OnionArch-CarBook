using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class anan : Migration
    {
        /// <inheritdoc />


        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppUserId",
                table: "Reviews",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AppUsers_AppUserId",
                table: "Reviews",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AppUsers_AppUserId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AppUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reviews");
        }
    }
}
