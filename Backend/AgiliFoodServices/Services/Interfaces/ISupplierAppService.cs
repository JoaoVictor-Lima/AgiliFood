using AgiliFoodServices.DataTranferObject;

namespace AgiliFoodServices.Services.Interfaces
{
    public interface ISupplierAppService
    {
        Task<IEnumerable<SupplierDTO>> GetAll();
        Task<SupplierDTO> GetById(int id);
        Task<SupplierDTO> Create(SupplierDTO dto);
        Task<SupplierDTO> Update(SupplierDTO dto);
        Task Delete(int id);
    }
}
