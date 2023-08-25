using AgiliFoodDomain.Entities;

namespace AgiliFoodServices.DataTranferObject
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DatePurchase { get; set; }
        public decimal TotalValue { get; set; }
        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}
