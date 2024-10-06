using Core.Services.Member.Dtos;
using Core.Services.Member;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Trainer;
using Core.Services.Trainer.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService service;

        public TrainerController(ITrainerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TrainerDto>>> Get()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("Id")]
        public async Task<TrainerDto> GetWithId(int id)
        {
            return await service.GetWithIdAsync(id);
        }

        [HttpDelete("Id")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Create(CreateUpdateTrainerDto trainer)
        {
            await service.CreateAsync(trainer);
        }

        [HttpPut("Id")]
        public async Task Update(int id, CreateUpdateTrainerDto trainer)
        {
            await service.UpdateAsync(id, trainer);
        }
    }
}
