using AutoMapper;
using SchoolManagement.Application.DTOs.LoginDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Domain.Models.LoginModel;
using SchoolManagement.Infrastructure.Common.Token;

namespace SchoolManagement.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        public LoginService(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<(string? token, bool check)> LoginAsync(LoginDto loginDto)
        {
            var login = _mapper.Map<Login>(loginDto);
            var token = await _loginRepository.LoginAsync(login);

            return token;
        }
    }
}
