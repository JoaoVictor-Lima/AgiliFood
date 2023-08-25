using AgiliFoodServices.DataTranferObject;
using AgiliFoodServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgiliFoodApplication.Controllers
{
    [Route("Api/v1/[controller]/[action]")]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorAppService _appService;

        public CollaboratorController(ICollaboratorAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IEnumerable<CollaboratorDTO>> GetAll()
        {
            return await _appService.GetAll();
        }

        [HttpGet]
        public async Task<CollaboratorDTO> GetById(int id)
        {
            try
            {
                return await _appService.GetById(id);
            }
            catch (Exception)
            {

                throw  new Exception($"Erro ao tentar acessar a entidade com o id {id}.");
            }
            
        }

        [HttpGet]
        public async Task<CollaboratorDTO> GetByEmail(string email)
        {
            return await _appService.GetByEmail(email);
        }

        [HttpPost]
        public async Task<CollaboratorDTO> Create([FromBody] CollaboratorDTO dto)
        {
            return await _appService.Create(dto);
        }


        [HttpPut]
        public async Task<CollaboratorDTO> Update([FromBody] CollaboratorDTO dto)
        {
            if(dto.Id < 1)
            {
                throw new Exception($"Impossivel atualizar a entidade com o id: {dto.Id}");
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
    }
}
