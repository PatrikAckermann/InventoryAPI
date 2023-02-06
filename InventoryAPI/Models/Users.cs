using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Models
{
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
