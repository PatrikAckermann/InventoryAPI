using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Controllers
{
    [Route("api/post/")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly InventoryContext _context;

        public PostController(InventoryContext context)
        {
            _context = context;
        }

        [HttpPost("location")]
        public async Task<ActionResult<Locations>> PostLocation(Locations location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostLocation", new { id = location.Id }, location);
        }

        [HttpPost("item")]
        public async Task<ActionResult<Inventory>> PostItem(Inventory inventory)
        {
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostItem", new {id = inventory.Id}, inventory);
        }
    }
}
