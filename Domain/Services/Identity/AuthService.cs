using AutoMapper;
using Core.IRepository;
using Core.Services.Identity.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Identity
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<Domain.Models.Member> _memberRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IGenericRepository<Domain.Models.Member> memberRepository, IConfiguration configuration, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        /*        public async Task<AuthResponseDto> RegisterAsync(RegisterMemberDto registerDto)
                {
                    // Check if the email is already registered
                    var existingMember = await _memberRepository.GetAll();
                    if (existingMember.Any(m => m.Email.Equals(registerDto.Email, StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new Exception("Email is already registered.");
                    }

                    // Create new member
                    var member = _mapper.Map<Domain.Models.Member>(registerDto);
                    member.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
                    await _memberRepository.Create(member);

                    return new AuthResponseDto
                    {
                        Token = GenerateJwtToken(member)
                    };
                }*/

        public async Task<AuthResponseDto> RegisterAsnyc(RegisterMemberDto registerDto)
        {
            // Check if the email is already registered
            var existingMember = await _memberRepository.GetAll();
            if (existingMember.Any(m => m.Email.Equals(registerDto.Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("Email is already registered.");
            }

            // Create new member
            var member = _mapper.Map<Domain.Models.Member>(registerDto);
            member.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            await _memberRepository.Create(member);

            return new AuthResponseDto
            {
                Token = GenerateJwtToken(member)
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var member = await _memberRepository.GetAll();
            var existingMember = member.FirstOrDefault(m => m.Email.Equals(loginDto.Email, StringComparison.OrdinalIgnoreCase));

            if (existingMember == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, existingMember.Password))
            {
                throw new Exception("Invalid email or password.");
            }

            return new AuthResponseDto
            {
                Token = GenerateJwtToken(existingMember)
            };
        }
        /*        private string GenerateJwtToken(Domain.Models.Member member)
                {
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
                    new Claim(ClaimTypes.Email, member.Email)
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }*/

        private string GenerateJwtToken(Domain.Models.Member member)
        {
            // Define the claims you want to include in the token
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()), // Member ID
        new Claim(ClaimTypes.Email, member.Email), // Member Email
        new Claim("FirstName", member.FirstName), // First Name
        new Claim("LastName", member.LastName), // Last Name
        new Claim("PhoneNumber", member.PhoneNumber ?? string.Empty), // Phone Number
        new Claim("DateOfBirth", member.DateOfBirth.ToString("o")), // Date of Birth in ISO 8601 format
        new Claim("MembershipStartDate", member.MemberShipStartDate.ToString("o")), // Membership Start Date
        new Claim("MembershipEndDate", member.MemberShipEndDate.ToString("o")), // Membership End Date
        new Claim(ClaimTypes.Role, "Member") // You can add roles if needed
    };

            // Create a security key using the key from configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Create the signing credentials using the key and the algorithm
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30), // Set token expiration
                signingCredentials: creds);

            // Write the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
