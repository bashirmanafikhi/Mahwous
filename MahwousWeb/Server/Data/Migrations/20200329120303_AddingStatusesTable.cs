using Microsoft.EntityFrameworkCore.Migrations;

namespace MahwousWeb.Server.Data.Migrations
{
    public partial class AddingStatusesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViewsCount = table.Column<int>(nullable: false),
                    DownloadsCount = table.Column<int>(nullable: false),
                    LikesCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    VideoPath = table.Column<string>(nullable: true),
                    CoverPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCategories",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCategories", x => new { x.StatusId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_StatusCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusCategories_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusCategories_CategoryId",
                table: "StatusCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusCategories");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
