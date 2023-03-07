using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Controllers
{
    [Route("api/delete")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private readonly InventoryContext _context;

        public DeleteController(InventoryContext context)
        {
            _context = context;
        }

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteUser([FromQuery]int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("category")]
        public async Task<IActionResult> DeleteCategory([FromQuery]int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("location")]
        public async Task<IActionResult> DeleteLocation([FromQuery]int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("object")]
        public async Task<IActionResult> DeleteObject([FromQuery]int id)
        {
            var obj = await _context.Objects.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Objects.Remove(obj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("item")]
        public async Task<IActionResult> DeleteItem([FromQuery]int id)
        {
            var item = await _context.Inventory.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
