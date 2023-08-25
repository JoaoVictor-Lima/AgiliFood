

using AgiliFoodDomain.Entities;
using AgiliFoodDomain.Interfaces;
using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics;

namespace AgiliFoodServices.Services.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var entities = await _productRepository.GetAll();
            var dtos = entities.Select(entity => MapProductToProductDto(entity));
            return dtos;
            
        }

        public async Task<ProductDTO> GetById(int id)
        {
            Product entity = await _productRepository.GetById(id);
            return MapProductToProductDto(entity);
        }

        public async Task<ProductDTO> Create(ProductDTO dto)
        {
            var entity = MapProductDtoToProduct(dto);
            entity = await _productRepository.Create(entity);
            return MapProductToProductDto(entity);
        }

        public async Task<ProductDTO> Update(ProductDTO dto)
        {
            var entity = MapProductDtoToProduct(dto);
            entity = await _productRepository.Update(entity);
            return MapProductToProductDto(entity);
        }

        public async Task Delete(int id)
        {
            await _productRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductDTO>> GetBySupplierId(int supplierId)
        {
            var entities = await _productRepository.GetBySupplierId(supplierId);
            var dtos = entities.Select(entity => MapProductToProductDto(entity));

            return dtos;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductByIds(List<int> productIds)
        {
            var entities = await _productRepository.GetProductsByIdsAsync(productIds);
            var dtos = entities.Select(entity => MapProductToProductDto(entity));
            return dtos;
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

        private ProductDTO MapProductToProductDto(Product entity)
        {
            return new ProductDTO
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
