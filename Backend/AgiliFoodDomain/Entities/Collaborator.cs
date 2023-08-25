

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiliFoodDomain.Entities
{
    public class Collaborator
    {
        [Key]
        public int Id { get; set; }
        [Column("varchar(100)")]
        public string Name { get; set; }
        [Column("varchar(200)")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; } 
    }
}
