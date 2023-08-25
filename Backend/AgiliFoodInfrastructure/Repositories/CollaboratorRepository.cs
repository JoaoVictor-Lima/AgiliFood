
using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AgiliFoodInfrastructure.Repositories
{
    public class CollaboratorRepository : RepositoryBase<Collaborator>, ICollaboratorRepository
    {
        public CollaboratorRepository(AgiliFoodDbContext context) : base(context)
        {
        }

        public async Task<Collaborator> GetByEmail(string email)
        {
            return await _context.Collaborators.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> IsEmailInUse(string email)
        {
            return await _context.Collaborators.AnyAsync(c => c.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
