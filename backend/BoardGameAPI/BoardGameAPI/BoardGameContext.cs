using BoardGameAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameAPI
{
    public class BoardGameContext : DbContext
    {
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<GamePiece> GamePieces { get; set; }
        public DbSet<BoardGamePiece> BoardGamePieces { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BoardGame_Summer2022;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardGame>().HasData(
                new BoardGame() { Id = 1, Name = "Omega Virus", MinPlayers = 1, MaxPlayers = 4, IsCoop = true, Genre = Genre.SocialDeduction },
                new BoardGame() { Id = 2, Name = "Mr Bacon's Big Adventure", MinPlayers = 2, MaxPlayers = 4, IsCoop = false, Genre = Genre.Family }
                );
            modelBuilder.Entity<GamePiece>().HasData(
                new GamePiece() { Id = 1, Name = "Dice", Material = Material.Plastic},
                new GamePiece() { Id = 2, Name = "Dice", Material = Material.Wood },
                new GamePiece() { Id = 3, Name = "Meeple", Material= Material.Wood },
                new GamePiece() { Id = 4, Name = "Stones", Material=Material.Marble}
                );
            modelBuilder.Entity<BoardGamePiece>().HasData(
                new BoardGamePiece() { Id = 1, BoardGameId = 2, GamePieceId = 1},
                new BoardGamePiece() { Id = 2, BoardGameId = 2, GamePieceId = 3}
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
