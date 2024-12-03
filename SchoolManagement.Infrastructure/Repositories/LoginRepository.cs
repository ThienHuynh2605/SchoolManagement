using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Domain.Models.LoginModel;
using SchoolManagement.Infrastructure.Common.Token;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SchoolDbContext _context;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public LoginRepository(SchoolDbContext context, IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<(string? token, bool check)> LoginAsync(Login login)
        {
            var student = await _context.Students
                .Include(s => s.Account)
                .SingleOrDefaultAsync(s => s.Account.UserName == login.UserName);

            if ((student != null) || (student.Account.Password == login.Password))
            {
                var token = _jwtTokenGenerator.StudentGenerateToken(student);

                return (token.ToString(), true);
            }

            return (null, false);
        }
    }
}
