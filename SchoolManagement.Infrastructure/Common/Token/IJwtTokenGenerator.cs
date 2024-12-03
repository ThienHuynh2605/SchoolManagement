using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Common.Token
{
    public interface IJwtTokenGenerator
    {
        public string StudentGenerateToken(Student student);
    }
}
