using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgiliFoodInfrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AgiliFoodDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Order>> GetAll() 
        {
            return await _context.Orders.Include(o => o.Products).ToListAsync();
        }

        public async Task AddProductsToOrder(Order order, IEnumerable<Product> products)
        {
            foreach (var product in products) 
            {
                var _product = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    SupplierId = product.SupplierId,
                };

                order.Products.Add(_product);
            }

            order.TotalValue = order.Products.Sum(p => p.Price);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCollaboratorId(int id)
        {
            var orders = await _context.Orders
                .Where(o => o.CollaboratorId == id)
                .AsNoTracking()
                .Include(o => o.Products)
                .ToListAsync();

            return orders;
        }
    }
}
