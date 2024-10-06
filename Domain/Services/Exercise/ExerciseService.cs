using AutoMapper;
using Core.IRepository;
using Core.Services.Exercise.Dtos;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exercise
{
    public class ExerciseService:IExerciseService
    {
        private readonly IGenericRepository<Domain.Models.Exercise> repo;
        private readonly IMapper mapper;

        public ExerciseService(IGenericRepository<Domain.Models.Exercise> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateUpdateExerciseDto exercise)
        {
            var result = mapper.Map<Domain.Models.Exercise>(exercise);
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

        public async Task<List<ExerciseDto>> GetAllAsync()
        {
            var result = await repo.GetAll();
            return mapper.Map<List<ExerciseDto>>(result);
        }

        public async Task<ExerciseDto> GetWithIdAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception();
            }
            return mapper.Map<ExerciseDto>(result);
        }

        public async Task UpdateAsync(int id, CreateUpdateExerciseDto exercise)
        {
            var result = await repo.GetWithId(id);
            var resultToReturn = mapper.Map(exercise, result);
            await repo.Update(resultToReturn);
        }
    }
}
