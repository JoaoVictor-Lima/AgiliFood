

using System.ComponentModel.DataAnnotations;

namespace AgiliFoodDomain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatePurchase { get; set; }
        public decimal TotalValue { get; set; }
        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
