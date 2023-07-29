using AgiliFoodDomain.Entities;
using AgiliFoodInfrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace AgiliFoodInfrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        protected AgileFoodDbContext _context;

        public SupplierRepository(AgileFoodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _context.Supplier.AsNoTracking().ToListAsync();
        }

        public async Task<Supplier> GetById(int id)
        {
            return await _context.Supplier.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<Supplier> Create(Supplier entity)
        {
            await _context.Supplier.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Supplier> Update(Supplier entity)
        {
            _context.Supplier.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Supplier.FindAsync(id);
            _context.Supplier.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }   
}
