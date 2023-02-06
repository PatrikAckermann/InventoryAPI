using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) {}

        public DbSet<Inventory> Inventory { get; set; } = null!;
        public DbSet<Objects> Objects { get; set; } = null!;
        public DbSet<Locations> Locations { get; set; } = null!;
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Categories> Categories { get; set; } = null!;
    }
}
