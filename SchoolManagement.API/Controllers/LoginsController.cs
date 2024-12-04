using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.LoginDtos;
using SchoolManagement.Application.IServices;

namespace SchoolManagement.API.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginsController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /*-------------------------Login Action-------------------------------*/
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var takeToken = await _loginService.LoginAsync(loginDto);
            if (takeToken.check == false)
            {
                return Unauthorized();
            }

            return Ok(new { Token = takeToken.token });
        }
    }
}
