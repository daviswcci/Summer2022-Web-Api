using BoardGameAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoardGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameController : ControllerBase
    {
        public BoardGameContext db { get; set; }
        public BoardGameController(BoardGameContext db)
        {
            this.db = db;
        }

        // Get (details)
        [HttpGet("{id}")]
        public ActionResult<BoardGame> Get(int id)
        {
            BoardGame boardGame = db.BoardGames.Find(id);
            if(boardGame == null) // not necessary, but since we're returning an action result, we can do this
            {
                return NotFound();
            }
            return boardGame;
        }

        // Get All (index)
        // Allows our user to specify a name that we want to look for within the names of the board games we return
        // in other words, we will use their input as a filter for our data
        [HttpGet]
        public ActionResult< IEnumerable<BoardGame> > GetAll([FromQuery]string? name) // binding a parameter from the query string
        {
            if(name != null)
            {
                // return filtered list
                return db.BoardGames.Where(bg => bg.Name.ToUpper().Contains( name.ToUpper() ) ).ToList(); // CATAN -> SETTLERS OF CATAN
            }
            return db.BoardGames;
        }

        // Post (create)
        [HttpPost]
        public ActionResult< IEnumerable<BoardGame> > Post(BoardGame boardGame)
        {
            
            if ( !BoardGameExists(boardGame.Name) ) // checking to see if a board game with the same name already exists in our db
            {
                db.BoardGames.Add(boardGame);
                db.SaveChanges();
            }

            return db.BoardGames;
        }
        
        // Put (update)
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<BoardGame>> Put(int id, BoardGame boardGame)
        {
            if(boardGame.Id == id)
            {
                db.BoardGames.Update(boardGame);
                db.SaveChanges();
            }

            return db.BoardGames;
        }

        // Delete (delete)
        [HttpDelete("{id}")]
        public ActionResult< IEnumerable<BoardGame> > Delete(int id)
        {
            BoardGame boardGame = db.BoardGames.Find(id);
            db.BoardGames.Remove(boardGame);
            db.SaveChanges();

            return db.BoardGames;
        }

        private bool BoardGameExists(string name)
        {
            BoardGame existing = db.BoardGames.Where(bg => bg.Name == name).FirstOrDefault(); // searches for a boardgame with an existing name
            return existing != null; // returns whether or not that object is null
        }
    }
}
