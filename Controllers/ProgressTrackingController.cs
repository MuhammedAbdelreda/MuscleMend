using Core.Services.Class.Dtos;
using Core.Services.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services.ProgessTracking;
using Core.Services.ProgessTracking.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressTrackingController : ControllerBase
    {
        private readonly IProgressTrackingService service;

        public ProgressTrackingController(IProgressTrackingService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProgressTrackingDto>>> Get()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("Id")]
        public async Task<ProgressTrackingDto> GetWithId(int id)
        {
            return await service.GetWithIdAsync(id);
        }

        [HttpDelete("Id")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Create(CreateUpdateProgressTrackingDto progressTracking)
        {
            await service.CreateAsync(progressTracking);
        }

        [HttpPut("Id")]
        public async Task Update(int id, CreateUpdateProgressTrackingDto progressTracking)
        {
            await service.UpdateAsync(id, progressTracking);
        }
    }
}
