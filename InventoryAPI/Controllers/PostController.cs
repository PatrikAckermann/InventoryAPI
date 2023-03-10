using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Net;

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

        [HttpPost("user")]
        public async Task<ActionResult<Users>> PostUser([FromForm]string name)
        {
            Users user = new Users();
            user.Name = name;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostUser", new { id = user.Id }, user);
        }

        [HttpPost("category")]
        public async Task<ActionResult<Categories>> PostCategory([FromForm]string name)
        {
            Categories category = new Categories();
            category.CategoryName = name;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostCategory", new {id = category.Id}, category);
        }

        [HttpPost("location")]
        public async Task<ActionResult<Locations>> PostLocation([FromForm]string name)
        {
            Locations location = new Locations();
            location.LocationName = name;
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostLocation", new { id = location.Id }, location);
        }

        [HttpPost("object")]
        public async Task<ActionResult<Objects>> PostObject([FromForm]string name, [FromForm]int category)
        {
            Objects obj = new Objects();
            obj.ObjectName = name;
            obj.Category = _context.Categories.Find(category);
            if(obj.Category == null || obj.ObjectName == null)
            {
                return BadRequest();
            }
            _context.Objects.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostObject", new {id = obj.Id}, obj);
        }

        [HttpPost("item")]
        public async Task<ActionResult<Inventory>> PostItem([FromForm]int objectType, [FromForm]int location, [FromForm]string description, [FromForm]int amount, [FromForm] int? user = null)
        {
            System.Diagnostics.Debug.WriteLine(objectType);
            if (objectType == 0 || location == 0 || amount == 0)
            {
                return BadRequest();
            }
            Inventory inventory = new Inventory();
            inventory.ObjectType = _context.Objects.Find(objectType);
            inventory.Location = _context.Locations.Find(location);
            inventory.Description = description;
            inventory.User = _context.Users.Find(user);
            inventory.Amount = amount;
            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostItem", new {id = inventory.Id}, inventory);
        }
    }
}