using Microsoft.EntityFrameworkCore.Migrations;

namespace MahwousWeb.Persistent.Data.Migrations
{
    public partial class VisibleStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Visible",
                table: "Statuses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Visible",
                table: "Statuses");
        }
    }
}
