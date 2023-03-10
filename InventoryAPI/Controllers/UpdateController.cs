using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InventoryAPI.Controllers
{
    [Route("api/update")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly InventoryContext _context;

        public UpdateController(InventoryContext context)
        {
            _context = context;
        }
        
        [HttpPut("user")]
        public async Task<IActionResult> UpdateUser([FromForm]int id, [FromForm]string name)
        {
            Users user = _context.Users.Find(id);
            if (user != null)
            {
                user.Name = name;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("category")]
        public async Task<IActionResult> UpdateCategory([FromForm]int id, [FromForm]string name)
        {
            Categories category = _context.Categories.Find(id);
            if (category != null)
            {
                category.CategoryName = name;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("location")]
        public async Task<IActionResult> UpdateLocation([FromForm]int id, [FromForm]string name)
        {
            Locations location = _context.Locations.Find(id);
            if (location != null)
            {
                location.LocationName = name;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("object")]
        public async Task<IActionResult> UpdateObject([FromForm]int id, [FromForm]int? category=null, [FromForm]string? name=null)
        {
            Objects obj = _context.Objects.Find(id);
            if (obj != null)
            {
                Categories categoryEntity = _context.Categories.Find(category);
                if (categoryEntity != null)
                {
                    obj.Category = categoryEntity;
                }
                if (name != null)
                {
                    obj.ObjectName = name;
                }
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
        
        [HttpPut("item")]
        public async Task<IActionResult> UpdateItem([FromForm]int id, [FromForm]int? objectType=null, [FromForm]int? location=null, [FromForm]string? description=null, [FromForm]int? user=null, [FromForm]int? amount=null)
        {
            Inventory item = _context.Inventory.Find(id);
            if (item != null)
            {
                Objects obj = _context.Objects.Find(objectType);
                if (obj != null)
                {
                    item.ObjectType = obj;
                }
                Locations loc = _context.Locations.Find(location);
                if (loc != null)
                {
                    item.Location = loc;
                }
                if(description != null)
                {
                    item.Description = description;
                }
                Users usr = _context.Users.Find(user);
                if (usr != null)
                {
                    item.User = usr;
                }
                if (amount != null)
                {
                    item.Amount = amount.Value;
                }
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
        
    }
}
