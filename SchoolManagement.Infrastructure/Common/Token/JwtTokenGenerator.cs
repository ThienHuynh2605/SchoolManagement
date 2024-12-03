using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models.Enums;
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

        public string GenerateToken<T>(T User, Role role)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = jwtSettings["Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

            switch (User)
            {
                case Student student:
                    claims.Add(new Claim("name", student.Name ?? string.Empty));
                    claims.Add(new Claim("email", student.Email ?? string.Empty));
                    break;

                case Teacher teacher:
                    claims.Add(new Claim("name", teacher.Name ?? string.Empty));
                    claims.Add(new Claim("email", teacher.Email ?? string.Empty));
                    break;

                case Principal principal:
                    claims.Add(new Claim("name", principal.Name ?? string.Empty));
                    claims.Add(new Claim("email", principal.Email ?? string.Empty));
                    break;

                default:
                    throw new ArgumentException("Unsupported user type.");
            }

            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));

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
