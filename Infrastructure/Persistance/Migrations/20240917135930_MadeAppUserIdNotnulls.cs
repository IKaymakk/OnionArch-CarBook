using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class MadeAppUserIdNotnulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Rezervasyons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Rezervasyons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

           
        }
    }
}
