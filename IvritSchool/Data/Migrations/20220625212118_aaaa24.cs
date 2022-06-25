using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class aaaa24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayedUsers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordType = table.Column<int>(type: "int", nullable: false),
                    TariffID = table.Column<int>(type: "int", nullable: true),
                    ClientStatus = table.Column<int>(type: "int", nullable: false),
                    LearnStartsFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    CurrentDayID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayedUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PayedUsers_BotUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "BotUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayedUsers_Days_CurrentDayID",
                        column: x => x.CurrentDayID,
                        principalTable: "Days",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PayedUsers_Tariff_TariffID",
                        column: x => x.TariffID,
                        principalTable: "Tariff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayedUsers_CurrentDayID",
                table: "PayedUsers",
                column: "CurrentDayID");

            migrationBuilder.CreateIndex(
                name: "IX_PayedUsers_TariffID",
                table: "PayedUsers",
                column: "TariffID");

            migrationBuilder.CreateIndex(
                name: "IX_PayedUsers_UserID",
                table: "PayedUsers",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayedUsers");
        }
    }
}
