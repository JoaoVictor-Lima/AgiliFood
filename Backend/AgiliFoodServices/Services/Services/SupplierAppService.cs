using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;

namespace AgiliFoodServices.Services.Services
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly ISupplierRepository _repository;

        public SupplierAppService(ISupplierRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<SupplierDTO>> GetAll()
        {
            var entities = await _repository.GetAll();
            var dtos = entities.Select(entity => MapSupplierToSupplierDto(entity));
            return dtos;
        }

        public async Task<SupplierDTO> GetById(int id)
        {
            Supplier entity = await _repository.GetById(id);
            return MapSupplierToSupplierDto(entity);
        }

        public async Task<SupplierDTO> Create(SupplierDTO dto)
        {

            var entity = MapSupplierDtoToSupplier(dto);
            entity = await _repository.Create(entity);
            return MapSupplierToSupplierDto(entity);
        }

        public async Task<SupplierDTO> Update(SupplierDTO dto)
        {
            var entity = MapSupplierDtoToSupplier(dto);
            entity = await _repository.Update(entity);
            return MapSupplierToSupplierDto(entity);
        }


        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        private SupplierDTO MapSupplierToSupplierDto(Supplier entity)
        {
            return new SupplierDTO
            {
                Id = entity.Id,
                RestaurantName = entity.RestaurantName,
                IsActive = entity.IsActive,
            };
        }

        private Supplier MapSupplierDtoToSupplier(SupplierDTO entity)
        {
            return new Supplier
            {
                Id = entity.Id,
                RestaurantName = entity.RestaurantName,
                IsActive = entity.IsActive
            };
        }

    }
}
