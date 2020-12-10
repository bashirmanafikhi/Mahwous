using Microsoft.EntityFrameworkCore.Migrations;

namespace MahwousWeb.Server.Data.Migrations
{
    public partial class SharesCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "SharesCount",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SharesCount",
                table: "Statuses");

            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
