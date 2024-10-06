using Core.Services.Class.Dtos;
using Core.Services.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services.WorkoutPlan;
using Core.Services.WorkoutPlan.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlanController : ControllerBase
    {
        private readonly IWorkoutPlanService service;

        public WorkoutPlanController(IWorkoutPlanService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutPlanDto>>> Get()
        {
            return await service.GetAllAsync();
        }

        [HttpGet("Id")]
        public async Task<WorkoutPlanDto> GetWithId(int id)
        {
            return await service.GetWithIdAsync(id);
        }

        [HttpDelete("Id")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Create(CreateUpdateWorkoutPlanDto workoutPlan)
        {
            await service.CreateAsync(workoutPlan);
        }

        [HttpPut("Id")]
        public async Task Update(int id, CreateUpdateWorkoutPlanDto workoutPlan)
        {
            await service.UpdateAsync(id, workoutPlan);
        }
    }
}
