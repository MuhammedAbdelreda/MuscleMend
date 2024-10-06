using AutoMapper;
using Core.IRepository;
using Core.Services.Class.Dtos;
using Core.Services.Trainer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Class
{
    public class ClassService : IClassService
    {
        private readonly IGenericRepository<Domain.Models.Class> repo;
        private readonly IMapper mapper;

        public ClassService(IGenericRepository<Domain.Models.Class> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateUpdateClassDto _class)
        {
            var result = mapper.Map<Domain.Models.Class>(_class);
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

        public async Task<List<ClassDto>> GetAllAsync()
        {
            var result = await repo.GetAll();
            return mapper.Map<List<ClassDto>>(result);
        }

        public async Task<ClassDto> GetWithIdAsync(int id)
        {
            var result = await repo.GetWithId(id);
            if (result == null)
            {
                throw new Exception();
            }
            return mapper.Map<ClassDto>(result);
        }

        public async Task UpdateAsync(int id, CreateUpdateClassDto _class)
        {
            var result = await repo.GetWithId(id);
            var resultToReturn = mapper.Map(_class, result);
            await repo.Update(resultToReturn);
        }
    }
}
