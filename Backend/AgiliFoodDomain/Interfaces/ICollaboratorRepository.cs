using AgiliFoodDomain.Entities;

namespace AgiliFoodDomain.Interfaces
{
    public interface ICollaboratorRepository : IRepositoryBase<Collaborator>
    {
        Task<Collaborator> GetByEmail(string email);
        Task<bool> IsEmailInUse(string email);
        Task SaveChangesAsync();
    }
}
