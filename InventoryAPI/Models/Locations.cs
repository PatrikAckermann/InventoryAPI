using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Locations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LocationName { get; set; } = null!;
    }
}
