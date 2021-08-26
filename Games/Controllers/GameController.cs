using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Games
{
    /// <summary>
    /// Controller class of movie
    /// </summary>
    /// <param name="GetGame"> Uses GET to print </param>>
    /// <param name="PutGame"> Uses PUT to update by id </param>>
    /// <param name="PostGame"> Uses POST to create new  </param>>
    /// <param name="DeleteGame"> Uses DELETE to delete data </param>>
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GamesContext _context;

        public GameController(GamesContext context)
        {
            _context = context;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            return await _context.Game.ToListAsync();
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Game/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _context.Entry(game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Game
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _context.Game.Add(game);
            await _context.SaveChangesAsync();

            Dictionary<string, string> _Links = new Dictionary<string, string>();
            _Links.Add("AddPlayed", "/api/Played");
            _Links.Add("AddWishlist", "/api/Wishlist");

            return Ok(JsonConvert.SerializeObject(new Model.HATEOAS() { Links = _Links }));
        }

        // DELETE: api/Game/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> DeleteGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return game;
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.Id == id);
        }
    }
}
