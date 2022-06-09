using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameServer.DAL.Migrations
{
    public partial class AddToTableServicePropertyHashGameSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashGameSession",
                table: "Servers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashGameSession",
                table: "Servers");
        }
    }
}
