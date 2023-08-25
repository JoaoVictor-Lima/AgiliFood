

using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgiliFoodInfrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AgiliFoodDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetBySupplierId(int supplierId)
        {
            var products = await _context.Products
            .Where(p => p.SupplierId == supplierId)
            .AsNoTracking()
             .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByIdsAsync(List<int> productIds)
        {
            var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToListAsync();

            return products;
        }
    }
}
