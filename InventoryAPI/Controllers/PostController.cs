using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly InventoryContext _context;

        public PostController(InventoryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Locations>> a(Locations locations)
        {
            _context.Locations.Add(locations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocations", new { id = locations.Id }, locations);
        }
    }
}
