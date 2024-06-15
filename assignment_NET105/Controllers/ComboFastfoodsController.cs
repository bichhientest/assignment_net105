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
    public class ComboFastfoodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComboFastfoodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ComboFastfoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComboFastfood>>> GetComboFastfood()
        {
            return await _context.ComboFastfood.ToListAsync();
        }

        // GET: api/ComboFastfoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComboFastfood>> GetComboFastfood(int id)
        {
            var comboFastfood = await _context.ComboFastfood.FindAsync(id);

            if (comboFastfood == null)
            {
                return NotFound();
            }

            return comboFastfood;
        }

        // PUT: api/ComboFastfoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComboFastfood(int id, ComboFastfood comboFastfood)
        {
            if (id != comboFastfood.ComboId)
            {
                return BadRequest();
            }

            _context.Entry(comboFastfood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComboFastfoodExists(id))
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

        // POST: api/ComboFastfoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComboFastfood>> PostComboFastfood(ComboFastfood comboFastfood)
        {
            _context.ComboFastfood.Add(comboFastfood);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComboFastfoodExists(comboFastfood.ComboId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComboFastfood", new { id = comboFastfood.ComboId }, comboFastfood);
        }

        // DELETE: api/ComboFastfoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComboFastfood(int id)
        {
            var comboFastfood = await _context.ComboFastfood.FindAsync(id);
            if (comboFastfood == null)
            {
                return NotFound();
            }

            _context.ComboFastfood.Remove(comboFastfood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComboFastfoodExists(int id)
        {
            return _context.ComboFastfood.Any(e => e.ComboId == id);
        }
    }
}
