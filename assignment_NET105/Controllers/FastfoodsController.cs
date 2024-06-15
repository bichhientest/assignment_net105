using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using assignment_NET105.Models;

namespace assignment_NET105.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastfoodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FastfoodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Fastfoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fastfood>>> GetFastfood()
        {
            return await _context.Fastfood.ToListAsync();
        }

        // GET: api/Fastfoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fastfood>> GetFastfood(int id)
        {
            var fastfood = await _context.Fastfood.FindAsync(id);

            if (fastfood == null)
            {
                return NotFound();
            }

            return fastfood;
        }

        // PUT: api/Fastfoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFastfood(int id, Fastfood fastfood)
        {
            if (id != fastfood.FastfoodId)
            {
                return BadRequest();
            }

            _context.Entry(fastfood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FastfoodExists(id))
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

        // POST: api/Fastfoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fastfood>> PostFastfood(Fastfood fastfood)
        {
            _context.Fastfood.Add(fastfood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFastfood", new { id = fastfood.FastfoodId }, fastfood);
        }

        // DELETE: api/Fastfoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFastfood(int id)
        {
            var fastfood = await _context.Fastfood.FindAsync(id);
            if (fastfood == null)
            {
                return NotFound();
            }

            _context.Fastfood.Remove(fastfood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FastfoodExists(int id)
        {
            return _context.Fastfood.Any(e => e.FastfoodId == id);
        }
    }
}
