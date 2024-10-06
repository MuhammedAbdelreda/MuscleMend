using Core.Services.Member.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Member
{
    public interface IMemberServices
    {
        Task CreateAsync(CreateUpdateMemberDto member);
        Task UpdateAsync(int id, CreateUpdateMemberDto member);
        Task DeleteAsync(int id);
        Task<List<MemberDto>> GetAll();
        Task<MemberDto> GetWithId(int id);
    }
}
