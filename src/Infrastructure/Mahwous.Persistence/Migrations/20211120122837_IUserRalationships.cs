using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahwous.Persistence.Migrations
{
    public partial class IUserRalationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MobileNotifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ExternalLinks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MobileNotifications_UserId",
                table: "MobileNotifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalLinks_UserId",
                table: "ExternalLinks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalLinks_AspNetUsers_UserId",
                table: "ExternalLinks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileNotifications_AspNetUsers_UserId",
                table: "MobileNotifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalLinks_AspNetUsers_UserId",
                table: "ExternalLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileNotifications_AspNetUsers_UserId",
                table: "MobileNotifications");

            migrationBuilder.DropIndex(
                name: "IX_MobileNotifications_UserId",
                table: "MobileNotifications");

            migrationBuilder.DropIndex(
                name: "IX_ExternalLinks_UserId",
                table: "ExternalLinks");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MobileNotifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ExternalLinks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
