using Microsoft.EntityFrameworkCore.Migrations;

namespace MahwousWeb.Persistent.Data.Migrations
{
    public partial class AddingviewsCountColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewsCount",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewsCount",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppleStoreOpenedCount",
                table: "Apps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayStoreOpenedCount",
                table: "Apps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ViewsCount",
                table: "Apps",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewsCount",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ViewsCount",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AppleStoreOpenedCount",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "PlayStoreOpenedCount",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "ViewsCount",
                table: "Apps");
        }
    }
}
