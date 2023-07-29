using AgiliFoodDomain.Entities;

namespace AgiliFoodInfrastructure.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAll();
        Task<Supplier> GetById(int id);
        Task<Supplier> Create(Supplier entity);
        Task<Supplier> Update(Supplier entity);
        Task Delete(int id);
    }
}
