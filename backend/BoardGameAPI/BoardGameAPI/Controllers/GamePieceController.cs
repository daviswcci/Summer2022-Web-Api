using BoardGameAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamePieceController : ControllerBase
    {
        public BoardGameContext db { get; set; }
        public GamePieceController(BoardGameContext db)
        {
            this.db = db;
        }

        // Get
        [HttpGet("{id}")]
        public ActionResult<GamePiece> Get(int id)
        {
            
            return db.GamePieces.Find(id);
        }
        // Get All
        [HttpGet]
        public ActionResult< IEnumerable<GamePiece> > GetAll()
        {
            return db.GamePieces;
        }
        // Put
        [HttpPut("{id}")]
        public ActionResult<GamePiece> Put(int id, GamePiece gamePiece)
        {
            if (gamePiece.Id == id)
            {
                db.GamePieces.Update(gamePiece);
                db.SaveChanges();
            }

            return gamePiece;
        }

        // Post
        [HttpPost]
        public ActionResult< IEnumerable<GamePiece> > Post(GamePiece gamePiece)
        {
            db.GamePieces.Add(gamePiece);
            db.SaveChanges();
            return db.GamePieces;
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult < IEnumerable <GamePiece> > Delete(int id)
        {
            GamePiece gamePiece = db.GamePieces.Find(id);
            db.GamePieces.Remove(gamePiece);
            db.SaveChanges();

            return db.GamePieces;
        }
    }
}
