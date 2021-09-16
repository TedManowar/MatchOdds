using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchOdds.Data;
using MatchOdds.Models;

namespace MatchOdds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchOddsController : ControllerBase
    {
        private readonly MatchOddsContext _context;

        public MatchOddsController(MatchOddsContext context)
        {
            _context = context;
        }

        // GET: api/MatchOdds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchOdd>>> GetMatchOdds()
        {
            return await _context.MatchOdds.ToListAsync();
        }

        // GET: api/MatchOdds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchOdd>> GetMatchOdd(int id)
        {
            var matchOdd = await _context.MatchOdds.FindAsync(id);

            if (matchOdd == null)
            {
                return NotFound();
            }

            return matchOdd;
        }

        // PUT: api/MatchOdds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchOdd(int id, MatchOdd matchOdd)
        {
            if (id != matchOdd.ID)
            {
                return BadRequest();
            }

            _context.Entry(matchOdd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchOddExists(id))
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

        // POST: api/MatchOdds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MatchOdd>> PostMatchOdd(MatchOdd matchOdd)
        {
            _context.MatchOdds.Add(matchOdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchOdd", new { id = matchOdd.ID }, matchOdd);
        }

        // DELETE: api/MatchOdds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MatchOdd>> DeleteMatchOdd(int id)
        {
            var matchOdd = await _context.MatchOdds.FindAsync(id);
            if (matchOdd == null)
            {
                return NotFound();
            }

            _context.MatchOdds.Remove(matchOdd);
            await _context.SaveChangesAsync();

            return matchOdd;
        }

        private bool MatchOddExists(int id)
        {
            return _context.MatchOdds.Any(e => e.ID == id);
        }
    }
}
