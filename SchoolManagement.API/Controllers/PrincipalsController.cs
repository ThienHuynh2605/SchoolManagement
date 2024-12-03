using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Interfaces.IServices;

namespace SchoolManagement.API.Controllers
{
    [Route("api/principals"), Authorize]
    [ApiController]
    public class PrincipalsController : ControllerBase
    {
        private readonly IPrincipalService _principalService;
        public PrincipalsController(IPrincipalService principalService)
        {
            _principalService = principalService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrincipalAsync([FromBody] CreatePrincipalDto principalDto)
        {
            await _principalService.CreatePrincipalAsync(principalDto);
            return Ok("Successfully.");
        }

        [HttpGet("isActive/{isActive}")]
        public async Task<IActionResult> GetPrincipalsAsync(bool isActive, int page = 1, int pageSize = 5)
        {
            var principal = await _principalService.GetPrincipalsAsync(isActive, page, pageSize);
            return Ok(principal);
        }

        [HttpGet("numbers")]
        public async Task<IActionResult> GetPrincipalNumberAsync()
        {
            var principalNumber = await _principalService.GetPrincipalNumbersAsync();
            return Ok(principalNumber);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrincipalByIdAsync(int id)
        {
            var principalDto = await _principalService.GetPrincipalByIdAsync(id);
            return Ok(principalDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrincipalAsync(int id, [FromBody] UpdatePrincipalDto principalDto)
        {
            await _principalService.UpdatePrincipalAsync(id, principalDto);
            return Ok("Successfully.");
        }

        [HttpPut("{id}/account")]
        public async Task<IActionResult> UpdatePrincipalAccountAsync(int id, [FromBody] PrincipalAccountDto accountDto)
        {
            await _principalService.UpdatePrincipalAccountAsync(id, accountDto);
            return Ok("Successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrincipalAsync(int id)
        {
            await _principalService.DeletePrincipalAsync(id);
            return Ok("Successfully.");
        }

        [HttpGet("{id}/teachers")]
        public async Task<IActionResult> GetPrincipalByIdTeachersAsync(int id, int page = 1, int pageSize = 5)
        {
            var teachersDto = await _principalService.GetPrincipalByIdTeachersAsync(id, page, pageSize);
            return Ok(teachersDto);
        }

        [HttpPost("{principalId}/add-teacher")]
        public async Task<IActionResult> AssignTeacherToPrincipalAsync(int principalId, AssignTeacherDto teacherAdd)
        {
            await _principalService.AssignTeacherToPrincipalAsync(principalId, teacherAdd);
            return Ok("Successfully.");
        }
    }
}
