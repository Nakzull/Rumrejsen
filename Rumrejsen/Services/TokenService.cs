using Microsoft.IdentityModel.Tokens;
using Rumrejsen.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rumrejsen.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));

            //Adds claims to the JWT token in this case the most important one is Role which is used to access the GetRoutes endpoint.
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Name, user.Name)
            };

            //Creates the JWT token including the claims, an expiration time of 1 hour and encrypt the string.
            var token = new JwtSecurityToken(null, null, claims, null, DateTime.Now.AddHours(1), new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature));

            string tokenvalue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenvalue;
        }
    }
}