using AutoMapper;
using Core.IRepository;
using Core.Services.Trainer.Dtos;
using Core.Services.WorkoutPlan.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.WorkoutPlan
{
    public class WorkoutPlanService:IWorkoutPlanService
    {
        private readonly IGenericRepository<Domain.Models.WorkoutPlan> repo;
        private readonly IMapper mapper;

        public WorkoutPlanService(IGenericRepository<Domain.Models.WorkoutPlan> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateUpdateWorkoutPlanDto workoutPlan)
        {
            var result = mapper.Map<Domain.Models.WorkoutPlan>(workoutPlan);
            await repo.Create(result);
        }

        public async Task DeleteAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception("Member not found");
            }
            await repo.Delete(result);
        }

        public async Task<List<WorkoutPlanDto>> GetAllAsync()
        {
            var result = await repo.GetAll();
            return mapper.Map<List<WorkoutPlanDto>>(result);
        }

        public async Task<WorkoutPlanDto> GetWithIdAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception();
            }
            return mapper.Map<WorkoutPlanDto>(result);
        }

        public async Task UpdateAsync(int id, CreateUpdateWorkoutPlanDto workoutPlan)
        {
            var result = await repo.GetWithId(id);
            var resultToReturn = mapper.Map(workoutPlan, result);
            await repo.Update(resultToReturn);
        }
    }
}
