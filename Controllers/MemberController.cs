using Core.Services.Member;
using Core.Services.Member.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IMemberServices service;

        public MemberController(IMemberServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberDto>>> Get()
        {
            return await service.GetAll(); 
        }

        [HttpGet("Id")]
        public async Task<MemberDto> GetWithId(int id)
        {
            return await service.GetWithId(id);
        }

        [HttpDelete("Id")]
        public async Task Delete(int id)
        {
             await service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task Create(CreateUpdateMemberDto member)
        {
            await service.CreateAsync(member);
        }

        [HttpPut("Id")]
        public async Task Update(int id,CreateUpdateMemberDto member)
        {
            await service.UpdateAsync(id, member);
        }
    }
}
