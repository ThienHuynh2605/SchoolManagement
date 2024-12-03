using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagement.Infrastructure.Common.Token
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string StudentGenerateToken(Student student)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = jwtSettings["Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("name", student.Name ?? string.Empty),
                new Claim("email", student.Email ?? string.Empty)
                //new Claim("Role", role.ToString())

            };

            var expiresInMinutes = jwtSettings["ExpiresInMinutes"];

            if (string.IsNullOrEmpty(expiresInMinutes))
            {
                expiresInMinutes = "1";
            }

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                expires: DateTime.UtcNow.AddMinutes(int.Parse(expiresInMinutes)),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials,
                claims: claims
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
