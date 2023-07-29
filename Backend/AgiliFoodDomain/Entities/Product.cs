using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgiliFoodDomain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }
        public decimal Price  { get; set; }
        public bool IsActive { get; set; }
        public Supplier Supplier { get; set; }
    }
}
