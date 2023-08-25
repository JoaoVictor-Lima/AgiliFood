
using AgiliFoodServices.DataTranferObject;

namespace AgiliFoodServices.Services.Interfaces
{
    public interface ICollaboratorAppService : IAppServiceBase<CollaboratorDTO>
    {
        Task<CollaboratorDTO> GetByEmail(string email);
    }
}
