using Core.Services.Class.Dtos;
using Core.Services.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services.Exercise;
using Core.Services.Exercise.Dtos;
using Domain.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService service;

        public ExerciseController(IExerciseService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExerciseDto>>> Get()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("Id")]
        public async Task<ExerciseDto> GetWithId(int id)
        {
            return await service.GetWithIdAsync(id);
        }

        [HttpDelete("Id")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Create(CreateUpdateExerciseDto exercise)
        {
            await service.CreateAsync(exercise);
        }

        [HttpPut("Id")]
        public async Task Update(int id, CreateUpdateExerciseDto exercise)
        {
            await service.UpdateAsync(id, exercise);
        }
    }
}
