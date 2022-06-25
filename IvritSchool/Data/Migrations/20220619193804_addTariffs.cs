using Microsoft.EntityFrameworkCore.Migrations;

namespace IvritSchool.Data.Migrations
{
    public partial class addTariffs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tariff",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariff", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DaysTariff",
                columns: table => new
                {
                    DaysID = table.Column<int>(type: "int", nullable: false),
                    TariffsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysTariff", x => new { x.DaysID, x.TariffsID });
                    table.ForeignKey(
                        name: "FK_DaysTariff_Days_DaysID",
                        column: x => x.DaysID,
                        principalTable: "Days",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaysTariff_Tariff_TariffsID",
                        column: x => x.TariffsID,
                        principalTable: "Tariff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaysTariff_TariffsID",
                table: "DaysTariff",
                column: "TariffsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysTariff");

            migrationBuilder.DropTable(
                name: "Tariff");
        }
    }
}
