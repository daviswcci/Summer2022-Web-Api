using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameAPI.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamePieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePieces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGamePieces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    GamePieceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGamePieces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGamePieces_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGamePieces_GamePieces_GamePieceId",
                        column: x => x.GamePieceId,
                        principalTable: "GamePieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GamePieces",
                columns: new[] { "Id", "Material", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Dice" },
                    { 2, 0, "Dice" },
                    { 3, 0, "Meeple" },
                    { 4, 2, "Stones" }
                });

            migrationBuilder.InsertData(
                table: "BoardGamePieces",
                columns: new[] { "Id", "BoardGameId", "GamePieceId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "BoardGamePieces",
                columns: new[] { "Id", "BoardGameId", "GamePieceId" },
                values: new object[] { 2, 2, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamePieces_BoardGameId",
                table: "BoardGamePieces",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamePieces_GamePieceId",
                table: "BoardGamePieces",
                column: "GamePieceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGamePieces");

            migrationBuilder.DropTable(
                name: "GamePieces");
        }
    }
}
