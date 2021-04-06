using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MahwousWeb.Persistent.Data.Migrations
{
    public partial class AddingNotificationAppsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "BadgeNumber",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotificationId",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "NotifyTime",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReturningData",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Notifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Categories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Apps",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Package",
                table: "Apps",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Apps",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "NotificationApps",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false),
                    AppId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationApps", x => new { x.NotificationId, x.AppId });
                    table.ForeignKey(
                        name: "FK_NotificationApps_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationApps_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationApps_AppId",
                table: "NotificationApps",
                column: "AppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationApps");

            migrationBuilder.DropColumn(
                name: "BadgeNumber",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotifyTime",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReturningData",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "Package",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Apps");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
