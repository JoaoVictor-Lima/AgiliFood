

using AgiliFoodServices.DataTranferObject;

namespace AgiliFoodServices.Services.Interfaces
{
    public interface IProductAppService : IAppServiceBase<ProductDTO>
    {
        Task<IEnumerable<ProductDTO>> GetBySupplierId(int id);
        Task<IEnumerable<ProductDTO>> GetProductByIds(List<int> productIds);
    }
}
