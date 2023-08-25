using AgiliFoodDomain.Entities;

namespace AgiliFoodDomain.Interfaces
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task AddProductsToOrder(Order order, IEnumerable<Product> products);
        Task<IEnumerable<Order>> GetOrdersByCollaboratorId(int id);
    }
}
