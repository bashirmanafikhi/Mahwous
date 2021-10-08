using Microsoft.EntityFrameworkCore.Migrations;

namespace MahwousWeb.Persistent.Migrations
{
    public partial class UpdateBaseEntityProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "Statuses",
                newName: "IsHidden");

            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "Posts",
                newName: "IsHidden");

            migrationBuilder.RenameColumn(
                name: "DownloadsCount",
                table: "Posts",
                newName: "SharesCount");

            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "Notifications",
                newName: "IsHidden");

            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "MobileApps",
                newName: "IsHidden");

            migrationBuilder.RenameColumn(
                name: "Visible",
                table: "Categories",
                newName: "IsHidden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsHidden",
                table: "Statuses",
                newName: "Visible");

            migrationBuilder.RenameColumn(
                name: "SharesCount",
                table: "Posts",
                newName: "DownloadsCount");

            migrationBuilder.RenameColumn(
                name: "IsHidden",
                table: "Posts",
                newName: "Visible");

            migrationBuilder.RenameColumn(
                name: "IsHidden",
                table: "Notifications",
                newName: "Visible");

            migrationBuilder.RenameColumn(
                name: "IsHidden",
                table: "MobileApps",
                newName: "Visible");

            migrationBuilder.RenameColumn(
                name: "IsHidden",
                table: "Categories",
                newName: "Visible");
        }
    }
}
