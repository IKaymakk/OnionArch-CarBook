using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class manytomanyblogtagcloud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagClouds",
                columns: table => new
                {
                    TagCloudId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagCloudTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagClouds", x => x.TagCloudId);
                });

            migrationBuilder.CreateTable(
                name: "BlogTagCloud",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    TagCloudId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTagCloud", x => new { x.BlogId, x.TagCloudId });
                    table.ForeignKey(
                        name: "FK_BlogTagCloud_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTagCloud_TagClouds_TagCloudId",
                        column: x => x.TagCloudId,
                        principalTable: "TagClouds",
                        principalColumn: "TagCloudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogTagCloud_TagCloudId",
                table: "BlogTagCloud",
                column: "TagCloudId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogTagCloud");

            migrationBuilder.DropTable(
                name: "TagClouds");
        }
    }
}
