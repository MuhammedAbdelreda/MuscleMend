using Core.Services.Exercise.Dtos;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exercise
{
    public interface IExerciseService
    {
        Task CreateAsync(CreateUpdateExerciseDto exercise);
        Task UpdateAsync(int id, CreateUpdateExerciseDto exercise);
        Task DeleteAsync(int id);
        Task<List<ExerciseDto>> GetAllAsync();
        Task<ExerciseDto> GetWithIdAsync(int id);
    }
}
