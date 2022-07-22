namespace BoardGameAPI.Models
{
    public class BoardGamePiece
    {
        public int Id { get; set; }
        public int BoardGameId { get; set; }
        public virtual BoardGame BoardGame { get; set; }
        public int GamePieceId { get; set; }
        public virtual GamePiece GamePiece { get; set; }
    }
}
