using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Mahwous.Persistence.Migrations
{
    public partial class ConvertModelsToTheNewModelsProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Statuses",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Notifications",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "MobileApps",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Categories",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Statuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Statuses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MobileApps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "MobileApps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "MobileApps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "MobileApps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedById",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MobileApps");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "MobileApps");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "MobileApps");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Statuses",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Notifications",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "MobileApps",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Categories",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MobileApps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
