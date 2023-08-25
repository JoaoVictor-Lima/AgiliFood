
using AgiliFoodDomain.Entities;

namespace AgiliFoodDomain.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public Task<IEnumerable<Product>> GetBySupplierId(int id);
        Task<IEnumerable<Product>> GetProductsByIdsAsync(List<int> productIds);
    }
}
