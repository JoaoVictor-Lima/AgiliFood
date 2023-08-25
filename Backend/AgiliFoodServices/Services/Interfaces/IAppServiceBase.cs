

namespace AgiliFoodServices.Services.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<TEntity> GetById(int id);
        public Task<TEntity> Create(TEntity dto);
        public Task<TEntity> Update(TEntity dto);
        public Task Delete(int id);
    }
}
