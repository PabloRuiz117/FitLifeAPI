using Domain.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    public class JWTService(IConfiguration config) : IJWTService
    {
        public string GenerateToken(ApplicationUser user)
        {
            var claims = new[]
             {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value.PadRight(64, '0')));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenExpiration = DateTime.UtcNow.AddDays(1);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: tokenExpiration,
                signingCredentials: creds);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
