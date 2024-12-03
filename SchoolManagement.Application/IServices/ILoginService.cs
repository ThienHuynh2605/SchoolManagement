using SchoolManagement.Application.DTOs.LoginDtos;

namespace SchoolManagement.Application.IServices
{
    public interface ILoginService
    {
        public Task<(string? token, bool check)> LoginAsync(LoginDto loginDto);
    }
}
