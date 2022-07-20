using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinPlayers = table.Column<int>(type: "int", nullable: false),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    IsCoop = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "Genre", "IsCoop", "MaxPlayers", "MinPlayers", "Name" },
                values: new object[] { 1, 6, true, 4, 1, "Omega Virus" });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "Genre", "IsCoop", "MaxPlayers", "MinPlayers", "Name" },
                values: new object[] { 2, 2, false, 4, 2, "Mr Bacon's Big Adventure" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGames");
        }
    }
}
