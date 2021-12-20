using Microsoft.EntityFrameworkCore.Migrations;

namespace Harmony.Data.Migrations
{
    public partial class PreparingForAddingFavoriteChords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfChords",
                table: "HarmonyModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsMagic",
                table: "HarmonyModel",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMagic",
                table: "HarmonyModel");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfChords",
                table: "HarmonyModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
