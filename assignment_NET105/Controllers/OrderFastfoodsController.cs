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
    public class OrderFastfoodsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderFastfoodsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderFastfoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderFastfood>>> GetOrderFastfoods()
        {
            return await _context.OrderFastfoods.ToListAsync();
        }

        // GET: api/OrderFastfoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderFastfood>> GetOrderFastfood(int id)
        {
            var orderFastfood = await _context.OrderFastfoods.FindAsync(id);

            if (orderFastfood == null)
            {
                return NotFound();
            }

            return orderFastfood;
        }

        // PUT: api/OrderFastfoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderFastfood(int id, OrderFastfood orderFastfood)
        {
            if (id != orderFastfood.OrderFastfoodId)
            {
                return BadRequest();
            }

            _context.Entry(orderFastfood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderFastfoodExists(id))
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

        // POST: api/OrderFastfoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderFastfood>> PostOrderFastfood(OrderFastfood orderFastfood)
        {
            _context.OrderFastfoods.Add(orderFastfood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderFastfood", new { id = orderFastfood.OrderFastfoodId }, orderFastfood);
        }

        // DELETE: api/OrderFastfoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderFastfood(int id)
        {
            var orderFastfood = await _context.OrderFastfoods.FindAsync(id);
            if (orderFastfood == null)
            {
                return NotFound();
            }

            _context.OrderFastfoods.Remove(orderFastfood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderFastfoodExists(int id)
        {
            return _context.OrderFastfoods.Any(e => e.OrderFastfoodId == id);
        }
    }
}
