using AutoMapper;
using Core.IRepository;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Trainer
{
    public class TrainerService : ITrainerService
    {
        private readonly IGenericRepository<Domain.Models.Trainer> repo;
        private readonly IMapper mapper;

        public TrainerService(IGenericRepository<Domain.Models.Trainer> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateUpdateTrainerDto trainer)
        {
            var result = mapper.Map<Domain.Models.Trainer>(trainer);
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

        public async Task<List<TrainerDto>> GetAllAsync()
        {
            var result = await repo.GetAll();
            return mapper.Map<List<TrainerDto>>(result);
        }

        public async Task<TrainerDto> GetWithIdAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception();
            }
            return mapper.Map<TrainerDto>(result);
        }

        public async Task UpdateAsync(int id, CreateUpdateTrainerDto trainer)
        {
            var result = await repo.GetWithId(id);
            var resultToReturn = mapper.Map(trainer, result);
            await repo.Update(resultToReturn);
        }
    }
}
