using Core.Services.Identity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Identity
{
    public interface IAuthService
    {
       Task<AuthResponseDto> RegisterAsnyc(RegisterMemberDto registerDto);
       Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}
