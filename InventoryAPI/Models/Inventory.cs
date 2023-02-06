using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Objects ObjectType { get; set; } = null!;
        public Locations Location { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Users User { get; set; }
        public int Amount { get; set; }
    }
}
