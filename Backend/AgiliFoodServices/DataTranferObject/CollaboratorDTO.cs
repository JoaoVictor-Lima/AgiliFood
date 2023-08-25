using AgiliFoodDomain.Entities;

namespace AgiliFoodServices.DataTranferObject
{
    public class CollaboratorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
