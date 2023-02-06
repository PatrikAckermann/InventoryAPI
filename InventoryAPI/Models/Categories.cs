using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Categories
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
