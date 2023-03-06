using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

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
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostUser", new { id = user.Id }, user);
        }

        [HttpPost("category")]
        public async Task<ActionResult<Categories>> PostCategory(Categories category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostCategory", new {id = category.Id}, category);
        }

        [HttpPost("location")]
        public async Task<ActionResult<Locations>> PostLocation(Locations location)
        {
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
                return NotFound();
            }
            _context.Objects.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostObject", new {id = obj.Id}, obj);
        }

        [HttpPost("item")]
        public async Task<ActionResult<Inventory>> PostItem([FromForm]int objectType, [FromForm]int location, [FromForm]string description, [FromForm]int amount, [FromForm] int? user = null)
        {
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

        [HttpPost("testpost")]
        public async Task<ActionResult<string>> TestPost([FromForm]int user)
        {
            Users User = _context.Users.Find(user);
            Console.WriteLine(User);
            if (User == null)
            {
                Console.WriteLine("ITS NULL");
            }
            return CreatedAtAction("TestPost", 1);
        }
    }
}