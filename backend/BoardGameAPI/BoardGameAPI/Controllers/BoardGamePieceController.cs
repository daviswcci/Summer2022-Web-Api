using BoardGameAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGamePieceController : ControllerBase
    {
        public BoardGameContext db { get; set; }
        public BoardGamePieceController(BoardGameContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public ActionResult<IEnumerable<BoardGame>> Post(BoardGamePiece boardGamePiece)
        {
            db.BoardGamePieces.Add(boardGamePiece);
            db.SaveChanges();

            return db.BoardGames;
        }
    }
}
