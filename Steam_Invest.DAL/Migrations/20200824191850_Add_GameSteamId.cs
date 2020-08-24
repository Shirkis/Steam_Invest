using Microsoft.EntityFrameworkCore.Migrations;

namespace Steam_Invest.DAL.Migrations
{
    public partial class Add_GameSteamId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameSteamId",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameSteamId",
                table: "Games");
        }
    }
}
