

using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodInfrastructure.Context;

namespace AgiliFoodInfrastructure.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AgiliFoodDbContext context) : base(context)
        {
        }
    }
}
