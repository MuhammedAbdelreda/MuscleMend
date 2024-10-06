using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal.Mappers;
using Core.IRepository;
using Core.Services.Member.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Member
{
    public class MemberServices : IMemberServices
    {
        private readonly IGenericRepository<Domain.Models.Member> repo;
        private readonly IMapper mapper;

        public MemberServices(IGenericRepository<Domain.Models.Member> repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task CreateAsync(CreateUpdateMemberDto member)
        {
            var result = mapper.Map<Domain.Models.Member>(member);
            await repo.Create(result);
            
        }

        public async Task DeleteAsync(int id)
        {
            var resultToDelete = await repo.GetWithId(id);
            if(resultToDelete == null)
            {
                throw new Exception("Member not found");
            }
            await repo.Delete(resultToDelete);
        }

        public async Task<List<MemberDto>> GetAll()
        {
            var result = await repo.GetAll();
            return mapper.Map<List<MemberDto>>(result);
        }

        public async Task<MemberDto> GetWithId(int id)
        {
            var result = await repo.GetWithId(id);
            if(result == null)
            {
                throw new Exception();
            }
            return mapper.Map<MemberDto>(result);
        }

        public async Task UpdateAsync(int id, CreateUpdateMemberDto member)
        {
            var result = await repo.GetWithId(id);
            var resultToUpdate = mapper.Map(member, result);
            await repo.Update(resultToUpdate);
        }
    }
}
