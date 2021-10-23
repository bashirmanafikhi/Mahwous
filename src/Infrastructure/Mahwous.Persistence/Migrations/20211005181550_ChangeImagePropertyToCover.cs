using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Mahwous.Persistence.Migrations
{
    public partial class ChangeImagePropertyToCover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileAppNotification");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Posts",
                newName: "CoverPath");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "MobileApps",
                newName: "CoverPath");

            migrationBuilder.CreateTable(
                name: "MobileNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturningData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BadgeNumber = table.Column<int>(type: "int", nullable: false),
                    RecivedCount = table.Column<int>(type: "int", nullable: false),
                    OpenedCount = table.Column<int>(type: "int", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    NotifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileAppMobileNotification",
                columns: table => new
                {
                    AppsId = table.Column<int>(type: "int", nullable: false),
                    NotificationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileAppMobileNotification", x => new { x.AppsId, x.NotificationsId });
                    table.ForeignKey(
                        name: "FK_MobileAppMobileNotification_MobileApps_AppsId",
                        column: x => x.AppsId,
                        principalTable: "MobileApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobileAppMobileNotification_MobileNotifications_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "MobileNotifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobileAppMobileNotification_NotificationsId",
                table: "MobileAppMobileNotification",
                column: "NotificationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobileAppMobileNotification");

            migrationBuilder.DropTable(
                name: "MobileNotifications");

            migrationBuilder.RenameColumn(
                name: "CoverPath",
                table: "Posts",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "CoverPath",
                table: "MobileApps",
                newName: "ImagePath");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BadgeNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    LastModifiedById = table.Column<int>(type: "int", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpenedCount = table.Column<int>(type: "int", nullable: false),
                    RecivedCount = table.Column<int>(type: "int", nullable: false),
                    ReturningData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ViewsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobileAppNotification",
                columns: table => new
                {
                    AppsId = table.Column<int>(type: "int", nullable: false),
                    NotificationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileAppNotification", x => new { x.AppsId, x.NotificationsId });
                    table.ForeignKey(
                        name: "FK_MobileAppNotification_MobileApps_AppsId",
                        column: x => x.AppsId,
                        principalTable: "MobileApps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobileAppNotification_Notifications_NotificationsId",
                        column: x => x.NotificationsId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobileAppNotification_NotificationsId",
                table: "MobileAppNotification",
                column: "NotificationsId");
        }
    }
}
