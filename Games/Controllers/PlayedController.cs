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
    /// Controller class of Played
    /// </summary>
    /// <param name="GetPlayed"> Uses GET to print </param>>
    /// <param name="PutPlayed"> Uses PUT to update by id </param>>
    /// <param name="PostPlayed"> Uses POST to create new  </param>>
    /// <param name="DeletePlayed"> Uses DELETE to delete data </param>>
    [Route("api/[controller]")]
    [ApiController]
    public class PlayedController : ControllerBase
    {
        private readonly GamesContext _context;

        public PlayedController(GamesContext context)
        {
            _context = context;
        }

        // GET: api/Played
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Played>>> GetPlayed()
        {
            return await _context.Played.ToListAsync();
        }

        // GET: api/Played/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Played>> GetPlayed(int id)
        {
            var seen = await _context.Played.FindAsync(id);

            if (seen == null)
            {
                return NotFound();
            }

            return seen;
        }

        // PUT: api/Played/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayed(int id, Played played)
        {
            if (id != played.Id)
            {
                return BadRequest();
            }

            _context.Entry(played).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayedExists(id))
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

        // POST: api/Played
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Played>> PostPlayed(Played played)
        {
            //if (_context.Game.Find().Id == played.Id)
            //    Console.WriteLine("KAZKAAAS");
                
            _context.Played.Add(played);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayed", new { id = played.Id }, played);
        }

        // DELETE: api/Played/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Played>> DeletePlayed(int id)
        {
            var seen = await _context.Played.FindAsync(id);
            if (seen == null)
            {
                return NotFound();
            }

            _context.Played.Remove(seen);
            await _context.SaveChangesAsync();

            return seen;
        }

        private bool PlayedExists(int id)
        {
            return _context.Played.Any(e => e.Id == id);
        }
    }
}
