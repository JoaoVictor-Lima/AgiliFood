using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AgiliFoodApplication.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    public class SupplierController : ControllerBase

    {
        private readonly ISupplierAppService _appService;

        public SupplierController(ISupplierAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierDTO>> GetAll()
        {
            return await _appService.GetAll();
        }

        [HttpGet]
        public async Task<SupplierDTO> GetById([FromQuery] int id)
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
        public async Task<SupplierDTO> Create([FromBody] SupplierDTO dto)
        {
            return await _appService.Create(dto);
        }

        [HttpPut]
        public async Task<SupplierDTO> Update([FromBody] SupplierDTO dto)
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

    }
}
