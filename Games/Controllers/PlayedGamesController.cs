using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Games
{
    /// <summary>
    /// Controller class of PlayedGames
    /// </summary>
    /// <param name="GetPlayedGames"> Uses GET to print </param>>
    /// <param name="PutPlayedGames"> Uses PUT to update by id </param>>
    /// <param name="PostPlayedGames"> Uses POST to create new  </param>>
    /// <param name="DeletePlayedGames"> Uses DELETE to delete data </param>>
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedGamesController : ControllerBase
    {
        private readonly GamesContext _context;

        public PlayedGamesController(GamesContext context)
        {
            _context = context;
        }

        // GET: api/PlayedGames
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayedGames>>> GetPlayedGames()
        {
            return await _context.PlayedGames.ToListAsync();
        }

        // GET: api/PlayedGames/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayedGames>> GetPlayedGames(int id)
        {
            var seen = await _context.PlayedGames.FindAsync(id);

            if (seen == null)
            {
                return NotFound();
            }

            return seen;
        }

        // PUT: api/PlayedGames/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayedGames(int id, PlayedGames playedGames)
        {
            if (id != playedGames.Id)
            {
                return BadRequest();
            }

            _context.Entry(playedGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayedGamesExists(id))
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

        // POST: api/PlayedGames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlayedGames>> PostPlayedGames(PlayedGames playedGames)
        {
            //if (_context.Game.Find().Id == seen.Id)
            //    Console.WriteLine("KAZKAAAS");
                
            _context.PlayedGames.Add(playedGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayedGames", new { id = playedGames.Id }, playedGames);
        }

        // DELETE: api/PlayedGames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayedGames>> DeletePlayedGames(int id)
        {
            var seen = await _context.PlayedGames.FindAsync(id);
            if (seen == null)
            {
                return NotFound();
            }

            _context.PlayedGames.Remove(seen);
            await _context.SaveChangesAsync();

            return seen;
        }

        private bool PlayedGamesExists(int id)
        {
            return _context.PlayedGames.Any(e => e.Id == id);
        }
    }
}
