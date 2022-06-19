using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class addfdsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Days_DaysID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DaysID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DaysID",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "DaysMessage",
                columns: table => new
                {
                    DaysID = table.Column<int>(type: "int", nullable: false),
                    MessagesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysMessage", x => new { x.DaysID, x.MessagesID });
                    table.ForeignKey(
                        name: "FK_DaysMessage_Days_DaysID",
                        column: x => x.DaysID,
                        principalTable: "Days",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaysMessage_Messages_MessagesID",
                        column: x => x.MessagesID,
                        principalTable: "Messages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaysMessage_MessagesID",
                table: "DaysMessage",
                column: "MessagesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysMessage");

            migrationBuilder.AddColumn<int>(
                name: "DaysID",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DaysID",
                table: "Messages",
                column: "DaysID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Days_DaysID",
                table: "Messages",
                column: "DaysID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
