using Microsoft.EntityFrameworkCore.Migrations;

namespace Harmony.Data.Migrations
{
    public partial class HarmonyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HarmonyModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FifthChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixthChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeventhChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EigthChord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfChords = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarmonyModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HarmonyModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HarmonyModel_UserId",
                table: "HarmonyModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HarmonyModel");
        }
    }
}
