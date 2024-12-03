using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.IServices;

namespace SchoolManagement.API.Controllers
{
    [Route("api/teachers"), Authorize]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> CreateTeacherAsync([FromBody] CreateTeacherDto teacherDto)
        {
            var createTeacher = await _teacherService.CreateTeacherAsync(teacherDto);
            return Ok(createTeacher);
        }

        [HttpGet]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> GetTeachersAsync(int page = 1, int pageSize = 5)
        {
            var teachers = await _teacherService.GetTeachersAsync(page, pageSize);
            return Ok(teachers);
        }

        [HttpGet("not-active")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> GetTeachersNotActiveAsync(int page = 1, int pageSize = 5)
        {
            var teachers = await _teacherService.GetTeachersNotActiveAsync(page, pageSize);
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> GetTeacherIdAsync(int id)
        {
            var teachers = await _teacherService.GetTeacherByIdAsync(id);
            return Ok(teachers);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> UpdateTeacherAsync(int id, [FromBody] UpdateTeacherDto teacherDto)
        {
            var teachers = await _teacherService.UpdateTeacherAsync(id, teacherDto);
            return Ok(teachers);    
        }

        [HttpGet("numbers")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> GetTeacherNumberAsync()
        {
            var teacherNumber = await _teacherService.GetTeacherNumbersAsync();
            return Ok(teacherNumber);
        }

        [HttpPatch("{id}")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> UpdateTeacherPartialAsync(int id, [FromBody] UpdateTeacherPartialDto teacherDto)
        {
            var updateTeacher = await _teacherService.UpdateTeacherPartialAsync(id, teacherDto);
            return Ok(updateTeacher);
        }

        [HttpPut("{teacherId}/account")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> UpdateTeacherAccountAsync(int teacherId, [FromBody] TeacherAccountDto accountDto)
        {
            var updateTeacherAccount = await _teacherService.UpdateTeacherAccountAsync(teacherId, accountDto);
            return Ok(updateTeacherAccount);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> DeleteTeacherAsync(int id)
        {
            var deleteTeacher = await _teacherService.DeleteTeacherAsync(id);
            return Ok(deleteTeacher);
        }

        [HttpGet("{id}/principals")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> GetTeacherByIdPrincipalsAsync(int id, int page = 1, int pageSize = 5)
        {
            var principalsDto = await _teacherService.GetTeacherByIdPrincipalsAsync(id, page, pageSize);
            return Ok(principalsDto);
        }
    }
}
