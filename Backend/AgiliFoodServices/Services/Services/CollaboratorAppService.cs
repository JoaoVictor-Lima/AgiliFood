using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;

namespace AgiliFoodServices.Services.Services
{
    public class CollaboratorAppService : ICollaboratorAppService
    {
        private readonly ICollaboratorRepository _repository;

        public CollaboratorAppService(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CollaboratorDTO>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = entities.Select(entity => MapCollaboratorToCollaboratorDTO(entity));
            return dtos;
        }

        public async Task<CollaboratorDTO> GetById(int id)
        {
            Collaborator entity = await _repository.GetById(id);
            return MapCollaboratorToCollaboratorDTO(entity);
        }

        public async Task<CollaboratorDTO> GetByEmail(string email)
        {
            if (email != null)
            {
                Collaborator entity = await _repository.GetByEmail(email);
                if(entity != null)
                {
                    return MapCollaboratorToCollaboratorDTO(entity);
                }
            }
            throw new ArgumentNullException("O campo de email não pode ser nulo.");
        }

        public async Task<CollaboratorDTO> Create(CollaboratorDTO dto)
        {
            if (dto.Email != null)
            {
                bool isEmailInUse = await _repository.IsEmailInUse(dto.Email);

                if (!isEmailInUse)
                {
                    var entity = MapCollaboratorDTOToCollaborator(dto);
                    entity = await _repository.Create(entity);
                    return MapCollaboratorToCollaboratorDTO(entity);
                }
                else
                {
                    throw new Exception("Email ja esta em uso");
                }
            }
            throw new ArgumentNullException("O campo de email não pode ser nulo.");
        }

        public async Task<CollaboratorDTO> Update(CollaboratorDTO dto)
        {
            var entity = MapCollaboratorDTOToCollaborator(dto);
            entity = await _repository.Update(entity);
            return MapCollaboratorToCollaboratorDTO(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public CollaboratorDTO MapCollaboratorToCollaboratorDTO(Collaborator entity)
        {
            return new CollaboratorDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                IsActive = entity.IsActive,
                Orders = entity.Orders
            };
        }

        public Collaborator MapCollaboratorDTOToCollaborator(CollaboratorDTO dto)
        {
            return new Collaborator
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                IsActive = dto.IsActive,
                Orders = dto.Orders
            };
        }

    }
}
