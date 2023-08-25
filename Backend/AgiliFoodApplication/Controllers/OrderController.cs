using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgiliFoodApplication.Controllers
{
    [Route("Api/v1/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _appService;

        public OrderController(IOrderAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            return await _appService.GetAll();
        }

        [HttpGet]
        public async Task<OrderDTO> GetById([FromQuery] int id)
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
        public async Task<OrderDTO> Create([FromBody] OrderDTO dto)
        {
            return await _appService.Create(dto);
        }

        [HttpPut]
        public async Task<OrderDTO> Update([FromBody] OrderDTO dto)
        {
            if (dto.Id < 1)
            {
                throw new Exception($"Impossivel atualizar a entidade com o id: {dto.Id}.");
            }

            return await _appService.Update(dto);
        }

        [HttpDelete]

        public async Task Delete([FromBody] int id)
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

        [HttpPost]
        public async Task<OrderDTO> AddProductsToOrder(int orderId, [FromBody]List<ProductDTO> productsDtos)
        {
            try
            {
                return await _appService.AddProductsToOrder(orderId, productsDtos);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao adicionar produtos");
            }
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetOrdersByCollaboratorId(int id)
        {
            try
            {
                return await _appService.GetOrdersByCollaboratorId(id);
            }
            catch (Exception)
            {

                throw new Exception($"Não foi encontrado nenhum collaborator com o id: {id}");
            }
        }
    }
}
