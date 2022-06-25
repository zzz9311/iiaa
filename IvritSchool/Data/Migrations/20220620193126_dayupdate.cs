using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class dayupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysMessage");

            migrationBuilder.AddColumn<int>(
                name: "DayID",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DayID",
                table: "Messages",
                column: "DayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Days_DayID",
                table: "Messages",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Days_DayID",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DayID",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DayID",
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
    }
}
