using AgiliFoodServices.DataTranferObject;

namespace AgiliFoodServices.Services.Interfaces
{
    public interface IOrderAppService : IAppServiceBase<OrderDTO>
    {
        Task<OrderDTO> AddProductsToOrder(int orderId, List<ProductDTO> productsDtos);
        Task<IEnumerable<OrderDTO>> GetOrdersByCollaboratorId(int id);
    }
}
