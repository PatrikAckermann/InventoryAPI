using InventoryAPI.Data;
using InventoryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace InventoryAPI.Controllers
{
    [Route("api/get/")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly InventoryContext _context;

        public GetController(InventoryContext context)
        {
            _context = context;
        }

        /*
         * Each database table has 2 API endpoints for getting data. One which only returns 1 result by ID and one which returns a list based on the parameters.
         */

        /******************************
        /         -- USERS --         /
        /*****************************/

        // Request by ID - Returns 1 user.
        [HttpGet("user/")] //{id}
        public async Task<ActionResult<Users>> GetUserId([FromQuery] int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // Request by parameters - Returns a list with users whose attributes match with the request.
        [HttpGet("user/list/")] //{name}
        public async Task<ActionResult<IEnumerable<Users>>> GetUserName([FromQuery] string? name="")
        {
            List<Users> users = await _context.Users.Where(x => x.Name.Contains(name)).ToListAsync();
            if (users == null) 
            {
                return NotFound();
            }

            return users;
        }

        /******************************
        /      -- Categories --       /
        /*****************************/

        // Request by ID - Returns 1 category.
        [HttpGet("category/")] //{id}
        public async Task<ActionResult<Categories>> GetCategoryId([FromQuery] int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // Request by parameters - Returns a list with categories whose attributes match with the request.
        [HttpGet("category/list/")] //{name}
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategoryName([FromQuery] string? name="")
        {
            List<Categories> categories = await _context.Categories.Where(x => x.CategoryName.Contains(name)).ToListAsync();
            if (categories == null)
            {
                return NotFound();
            }
            return categories;
        }

        /******************************
        /       -- Locations --       /
        /*****************************/

        // Request by ID - Returns 1 location.
        [HttpGet("location/")] //{id}
        public async Task<ActionResult<Locations>> GetLocationId([FromQuery] int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return location;
        }

        // Request by parameters - Returns a list with locations whose attributes match with the request.
        [HttpGet("location/list/")] //{LocationName}
        public async Task<ActionResult<IEnumerable<Locations>>> GetLocationName([FromQuery] string? name="")
        {
            List<Locations> locations = await _context.Locations.Where(x => x.LocationName.Contains(name)).ToListAsync();
            if (locations == null)
            {
                return NotFound();
            }
            return locations;
        }

        /******************************
        /        -- Objects --        /
        /*****************************/

        // Request by Id - Returns 1 Object.
        [HttpGet("object/")] //{id}
        public async Task<ActionResult<Objects>> GetObjectId([FromQuery] int id)
        {
            var obj = await _context.Objects.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return obj;
        }

        // Request by parameters - Returns a list with objects whose attributes match with the request.
        [HttpGet("object/list/")] //{category}
        public async Task<ActionResult<IEnumerable<Objects>>> GetObjectCategory([FromQuery] int? Category=null, [FromQuery] string? Name=null)
        {
            IQueryable<Objects> query = _context.Objects;
            if (Category != null)
            {
                query = query.Where(x => x.Category.Id == Category);
            }
            if (Name != null)
            {
                query = query.Where(x => x.ObjectName.Contains(Name));
            }
            query = query.Include(x => x.Category);
            List<Objects> Objects = await query.ToListAsync();

            if (Objects == null)
            {
                return NotFound();
            }
            return Objects;
        }

        /******************************
        /       -- Inventory --       /
        /*****************************/

        // Request by Id - Returns 1 item
        [HttpGet("item/")] //{itemid}
        public async Task<ActionResult<Inventory>> GetItemId([FromQuery] int id)
        {
            var obj = await _context.Inventory.Include(x => x.ObjectType).Include(x => x.Location).Include(x => x.User).Include(x => x.ObjectType.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // Request by parameters - Returns a list with inventory entries whose attributes match with the request.
        [HttpGet("item/list/")] //{ObjectType?}/{Location?}/{Description?}/{User?}/{minAmount?}/{maxAmount?}
        public async Task<ActionResult<IEnumerable<Inventory>>> GetItems([FromQuery]int? ObjectType = null, [FromQuery] int? Location = null, [FromQuery] string? Description = null, [FromQuery] int? User = null, [FromQuery] int? minAmount = null, [FromQuery] int? maxAmount = null)
        {
            IQueryable<Inventory> query = _context.Inventory;
            if (ObjectType != null)
            {
                query = query.Where(x => x.ObjectType.Id == ObjectType);
            }
            if (Location != null)
            {
                query = query.Where(x => x.Location.Id == Location);
            }
            if (Description != null)
            {
                query = query.Where(x => x.Description.Contains(Description));
            }
            if (User != null)
            {
                query = query.Where(x => x.User.Id == User);
            }
            if (minAmount != null)
            {
                query = query.Where(x => x.Amount >= minAmount);
            }
            if (maxAmount != null)
            {
                query = query.Where(x => x.Amount <= maxAmount);
            }

            query = query.Include(x => x.ObjectType).Include(x => x.Location).Include(x => x.User).Include(x => x.ObjectType.Category);
            List<Inventory> Items = await query.ToListAsync();

            if (Items == null)
            {
                return NotFound();
            }
            return Items;
        }
    }
}