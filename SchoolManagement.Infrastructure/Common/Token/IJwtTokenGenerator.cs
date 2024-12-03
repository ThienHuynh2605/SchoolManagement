using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models.Enums;

namespace SchoolManagement.Infrastructure.Common.Token
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken<T>(T User, Role role);
    }
}
