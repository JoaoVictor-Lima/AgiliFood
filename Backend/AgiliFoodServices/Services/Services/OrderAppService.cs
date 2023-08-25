

using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodInfrastructure.Repositories;
using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AgiliFoodServices.Services.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;


        public OrderAppService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var entities = await _orderRepository.GetAll();
            var dtos = entities.Select(entity => MapOrderToOrderDTO(entity));
            return dtos;

        }

        public async Task<OrderDTO> GetById(int id)
        {
            Order entity = await _orderRepository.GetById(id);
            return MapOrderToOrderDTO(entity);
        }

        public async Task<OrderDTO> Create(OrderDTO dto)
        {
            var entity = MapOrderDtoToOrder(dto);
            entity = await _orderRepository.Create(entity);
            return MapOrderToOrderDTO(entity);
        }

        public async Task<OrderDTO> Update(OrderDTO dto)
        {
            var entity = MapOrderDtoToOrder(dto);
            entity = await _orderRepository.Update(entity);
            return MapOrderToOrderDTO(entity);
        }

        public async Task Delete(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<OrderDTO> AddProductsToOrder(int orderId, List<ProductDTO> productsDtos)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                throw new Exception($"Não foi encontrado order com o id: {orderId}");
            }

            var products = productsDtos.Select(entity => MapProductDtoToProduct(entity));

            await _orderRepository.AddProductsToOrder(order, products);

            return MapOrderToOrderDTO(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByCollaboratorId(int id)
        {
            var entities = await _orderRepository.GetOrdersByCollaboratorId(id);
            var dtos = entities.Select(entity => MapOrderToOrderDTO(entity));
            return dtos;
        }

        private Order MapOrderDtoToOrder(OrderDTO entity)
        {
            return new Order
            {
                Id = entity.Id,
                DatePurchase = entity.DatePurchase,
                TotalValue = entity.TotalValue,
                CollaboratorId = entity.CollaboratorId,
                Collaborator = entity.Collaborator,
                Products = entity.Products.Select(product => new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    SupplierId = product.SupplierId,
                }).ToList()
            };
        }

        private OrderDTO MapOrderToOrderDTO(Order entity)
        {
            var orderDTO = new OrderDTO
            {
                Id = entity.Id,
                DatePurchase = entity.DatePurchase,
                TotalValue = entity.TotalValue,
                CollaboratorId = entity.CollaboratorId,
                Collaborator = entity.Collaborator,
                Products = entity.Products.Select(product => new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    SupplierId = product.SupplierId,
                }).ToList()
            };
            return orderDTO;
        }

        private Product MapProductDtoToProduct(ProductDTO entity)
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                IsActive = entity.IsActive,
                SupplierId = entity.SupplierId,
                Supplier = entity.Supplier
            };
        }

    }
}
