namespace BoardGameAPI.Models
{
    public class GamePiece
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Material Material { get; set; }
        public virtual List<BoardGamePiece> BoardGames { get; set; }
    }
    public enum Material
    {
        Wood,
        Plastic,
        Marble,
        Rubber,
        Metal
    }
}
