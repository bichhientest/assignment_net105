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
    public class OrderComboesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderComboesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderComboes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderCombo>>> GetOrderCombos()
        {
            return await _context.OrderCombos.ToListAsync();
        }

        // GET: api/OrderComboes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderCombo>> GetOrderCombo(int id)
        {
            var orderCombo = await _context.OrderCombos.FindAsync(id);

            if (orderCombo == null)
            {
                return NotFound();
            }

            return orderCombo;
        }

        // PUT: api/OrderComboes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderCombo(int id, OrderCombo orderCombo)
        {
            if (id != orderCombo.OrderComboId)
            {
                return BadRequest();
            }

            _context.Entry(orderCombo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderComboExists(id))
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

        // POST: api/OrderComboes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderCombo>> PostOrderCombo(OrderCombo orderCombo)
        {
            _context.OrderCombos.Add(orderCombo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderCombo", new { id = orderCombo.OrderComboId }, orderCombo);
        }

        // DELETE: api/OrderComboes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderCombo(int id)
        {
            var orderCombo = await _context.OrderCombos.FindAsync(id);
            if (orderCombo == null)
            {
                return NotFound();
            }

            _context.OrderCombos.Remove(orderCombo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderComboExists(int id)
        {
            return _context.OrderCombos.Any(e => e.OrderComboId == id);
        }
    }
}
