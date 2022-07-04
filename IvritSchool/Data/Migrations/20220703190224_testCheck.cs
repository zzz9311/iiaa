using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class testCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextDayID",
                table: "PayedUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MessagesToSendID",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sent",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MessagesToSend",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesToSend", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MessagesToSend_BotUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "BotUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayedUsers_NextDayID",
                table: "PayedUsers",
                column: "NextDayID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessagesToSendID",
                table: "Messages",
                column: "MessagesToSendID");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesToSend_UserID",
                table: "MessagesToSend",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessagesToSend_MessagesToSendID",
                table: "Messages",
                column: "MessagesToSendID",
                principalTable: "MessagesToSend",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PayedUsers_Days_NextDayID",
                table: "PayedUsers",
                column: "NextDayID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessagesToSend_MessagesToSendID",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_PayedUsers_Days_NextDayID",
                table: "PayedUsers");

            migrationBuilder.DropTable(
                name: "MessagesToSend");

            migrationBuilder.DropIndex(
                name: "IX_PayedUsers_NextDayID",
                table: "PayedUsers");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessagesToSendID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "NextDayID",
                table: "PayedUsers");

            migrationBuilder.DropColumn(
                name: "MessagesToSendID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Sent",
                table: "Messages");
        }
    }
}
