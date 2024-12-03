using SchoolManagement.Domain.Models.LoginModel;

namespace SchoolManagement.Domain.IRepositories
{
    public interface ILoginRepository
    {
        public Task<(string? token, bool check)> LoginAsync(Login login);
    }
}
