using AutoMapper;
using Core.IRepository;
using Core.Services.ProgessTracking.Dtos;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.ProgessTracking
{
    public class ProgressTrackingService:IProgressTrackingService
    {
        private readonly IGenericRepository<Domain.Models.ProgressTracking> repo;
        private readonly IMapper mapper;

        public ProgressTrackingService(IGenericRepository<Domain.Models.ProgressTracking> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateUpdateProgressTrackingDto progressTracking)
        {
            var result = mapper.Map<Domain.Models.ProgressTracking>(progressTracking);
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

        public async Task<List<ProgressTrackingDto>> GetAllAsync()
        {
            var result = await repo.GetAll();
            return mapper.Map<List<ProgressTrackingDto>>(result);
        }

        public async Task<ProgressTrackingDto> GetWithIdAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception();
            }
            return mapper.Map<ProgressTrackingDto>(result);
        }

        public async Task UpdateAsync(int id, CreateUpdateProgressTrackingDto progressTracking)
        {
            var result = await repo.GetWithId(id);
            var resultToReturn = mapper.Map(progressTracking, result);
            await repo.Update(resultToReturn);
        }
    }
}
