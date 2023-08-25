
using AgiliFoodDomain.Entities;

namespace AgiliFoodServices.DataTranferObject
{
    public class ProductDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
