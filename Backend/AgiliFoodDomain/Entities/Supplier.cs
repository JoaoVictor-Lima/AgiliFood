using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiliFoodDomain.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? RestaurantName { get; set; }
        public bool IsActive { get; set; }
    }
}
