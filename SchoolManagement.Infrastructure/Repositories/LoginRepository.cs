using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Domain.Models.Enums;
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

            if ((student != null) || (student?.Account?.Password == login.Password))
            {
                var token = _jwtTokenGenerator.GenerateToken(student, Role.Student);

                return (token.ToString(), true);
            }

            var teacher = await _context.Teachers
                .Include(s => s.Account)
                .SingleOrDefaultAsync(s => s.Account.UserName == login.UserName);

            if ((teacher != null) || (teacher?.Account?.Password == login.Password))
            {
                var token = _jwtTokenGenerator.GenerateToken(teacher, Role.Teacher);

                return (token.ToString(), true);
            }

            var principal = await _context.Principals
                .Include(s => s.Account)
                .SingleOrDefaultAsync(s => s.Account.UserName == login.UserName);

            if ((principal != null) || (principal?.Account?.Password == login.Password))
            {
                var token = _jwtTokenGenerator.GenerateToken(principal, Role.Principal);

                return (token.ToString(), true);
            }

            return (null, false);
        }
    }
}
