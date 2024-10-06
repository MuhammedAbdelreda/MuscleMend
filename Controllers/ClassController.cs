using Core.Services.Trainer.Dtos;
using Core.Services.Trainer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Class;
using Core.Services.Class.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService service;

        public ClassController(IClassService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClassDto>>> Get()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("Id")]
        public async Task<ClassDto> GetWithId(int id)
        {
            return await service.GetWithIdAsync(id);
        }

        [HttpDelete("Id")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Create(CreateUpdateClassDto _class)
        {
            await service.CreateAsync(_class);
        }

        [HttpPut("Id")]
        public async Task Update(int id, CreateUpdateClassDto _class)
        {
            await service.UpdateAsync(id, _class);
        }
    }
}
