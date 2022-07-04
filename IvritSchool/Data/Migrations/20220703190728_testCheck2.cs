using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class testCheck2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_MessagesToSend_MessagesToSendID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_MessagesToSendID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessagesToSendID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Sent",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "MessagesID",
                table: "MessagesToSend",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sent",
                table: "MessagesToSend",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_MessagesToSend_MessagesID",
                table: "MessagesToSend",
                column: "MessagesID");

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesToSend_Messages_MessagesID",
                table: "MessagesToSend",
                column: "MessagesID",
                principalTable: "Messages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessagesToSend_Messages_MessagesID",
                table: "MessagesToSend");

            migrationBuilder.DropIndex(
                name: "IX_MessagesToSend_MessagesID",
                table: "MessagesToSend");

            migrationBuilder.DropColumn(
                name: "MessagesID",
                table: "MessagesToSend");

            migrationBuilder.DropColumn(
                name: "Sent",
                table: "MessagesToSend");

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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessagesToSendID",
                table: "Messages",
                column: "MessagesToSendID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_MessagesToSend_MessagesToSendID",
                table: "Messages",
                column: "MessagesToSendID",
                principalTable: "MessagesToSend",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
