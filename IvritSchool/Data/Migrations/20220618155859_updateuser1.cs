using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class updateuser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBannded",
                table: "BotUsers",
                newName: "IsBanned");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstDate",
                table: "BotUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BotUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstDate",
                table: "BotUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BotUsers");

            migrationBuilder.RenameColumn(
                name: "IsBanned",
                table: "BotUsers",
                newName: "IsBannded");
        }
    }
}
