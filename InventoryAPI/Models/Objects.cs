using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Objects
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ObjectName { get; set; } = null!;
        public Categories Category { get; set; }
    }
}
