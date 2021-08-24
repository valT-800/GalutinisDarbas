﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Games
{
    /// <summary>
    /// Controller class of wishlist
    /// </summary>
    /// <param name="GetWishlist"> Uses GET to print </param>>
    /// <param name="PutWishlist"> Uses PUT to update by id </param>>
    /// <param name="PostWishlist"> Uses POST to create new  </param>>
    /// <param name="DeleteWishlist"> Uses DELETE to delete data </param>>
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly GamesContext _context;

        public WishlistController(GamesContext context)
        {
            _context = context;
        }

        // GET: api/Wishlist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist()
        {
            return await _context.Wishlist.ToListAsync();
        }

        // GET: api/Wishlist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
            var wishlist = await _context.Wishlist.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }

        // PUT: api/Wishlist/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int id, Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlist
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
            _context.Wishlist.Add(wishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
        }

        // DELETE: api/Wishlist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Wishlist>> DeleteWishlist(int id)
        {
            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlist.Remove(wishlist);
            await _context.SaveChangesAsync();

            return wishlist;
        }

        private bool WishlistExists(int id)
        {
            return _context.Wishlist.Any(e => e.Id == id);
        }
    }
}
