using Core.Services.Trainer.Dtos;
using Core.Services.WorkoutPlan.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.WorkoutPlan
{
    public interface IWorkoutPlanService
    {
        Task CreateAsync(CreateUpdateWorkoutPlanDto workoutPlan);
        Task UpdateAsync(int id, CreateUpdateWorkoutPlanDto workoutPlan);
        Task DeleteAsync(int id);
        Task<List<WorkoutPlanDto>> GetAllAsync();
        Task<WorkoutPlanDto> GetWithIdAsync(int id);
    }
}
