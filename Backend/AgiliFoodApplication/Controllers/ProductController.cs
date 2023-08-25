using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgiliFoodApplication.Controllers
{
    [Route("Api/v1/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _appService;

        public ProductController(IProductAppService productAppService)
        {
            _appService = productAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return await _appService.GetAll();
        }

        [HttpGet]
        public async Task<ProductDTO> GetById(int id)
        {
            try
            {
                return await _appService.GetById(id);
            }
            catch (Exception)
            {

                throw new Exception($"Erro ao tentar acessar a entidade com o id {id}.");
            }
            
        }

        [HttpPost]
        public async Task<ProductDTO> Create([FromBody] ProductDTO dto)
        {
            return await _appService.Create(dto);
        }

        [HttpPut]
        public async Task<ProductDTO> Update([FromBody] ProductDTO dto)
        {
            if (dto.Id < 1)
            {
                throw new Exception($"Impossivel atualizar a entidade com o id: {dto.Id}.");
            }

            return await _appService.Update(dto);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            if (id < 1)
            {
                throw new Exception($"Impossivel deletar a entidade com o id: {id}");
            }
            try
            {
                await _appService.Delete(id);
            }
            catch (Exception)
            {

                throw new Exception($"Erro ao tentar excluir a entidade com o id: {id}");
            }
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetBySupplierId(int id)
        {
            return await _appService.GetBySupplierId(id);
        }

        [HttpGet("get-by-ids")]
        public async Task<IActionResult> GetProductByIds([FromQuery] List<int> productIds)
        {
            var products = await _appService.GetProductByIds(productIds);

            if(products == null || !products.Any())
            {
                return NotFound();
            }

            return Ok(products);

        }
    }
}
