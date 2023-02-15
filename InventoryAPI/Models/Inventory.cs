using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Objects ObjectType { get; set; }
        public Locations Location { get; set; }
        public string Description { get; set; }
        public Users User { get; set; }
        public int Amount { get; set; }
    }
}
