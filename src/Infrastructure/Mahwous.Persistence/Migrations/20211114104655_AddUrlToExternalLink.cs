using Microsoft.EntityFrameworkCore.Migrations;

namespace Mahwous.Persistence.Migrations
{
    public partial class AddUrlToExternalLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ExternalLinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "ExternalLinks");
        }
    }
}
