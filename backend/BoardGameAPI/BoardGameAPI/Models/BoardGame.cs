namespace BoardGameAPI.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public Genre Genre { get; set; }
        public bool IsCoop { get; set; }
        public virtual List<BoardGamePiece> GamePieces { get; set; }
    }
    public enum Genre
    {
        Strategy,
        RPG,
        Family,
        Card,
        Horror, 
        Mystery,
        SocialDeduction,
        Abstract,
        AreaControl
    }
}
