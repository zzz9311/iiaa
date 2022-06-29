using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class frwmsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ForwardedGroup",
                table: "Messages",
                type: "bigint",
                nullable: true,
                defaultValue: null);

            migrationBuilder.AddColumn<int>(
                name: "ForwardedMessage",
                table: "Messages",
                type: "int",
                nullable: true,
                defaultValue: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForwardedGroup",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ForwardedMessage",
                table: "Messages");
        }
    }
}
