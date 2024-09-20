using Payroll.Application.DTOs.Setup;
using Payroll.Application.InterfaceRepository.Setup;
using Payroll.Application.InterfaceService.Setup;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Payroll.Application.Services.Setup
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTOs> AuthenticateAsync(LoginRequestDTOs request)
        {
            var user = await _userRepository.ValidateUserAsync(request.Username, request.Password);
            if (user == null)
            {
                return null;
            }

            var token = GenerateJwtToken(user);
            return new LoginResponseDTOs
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1)
            };
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
       {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
