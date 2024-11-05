using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Domain.Interfaces.IServices;

namespace SchoolManagement.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var studentsDto = await _studentService.GetStudentsAsync();
            return Ok(studentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var studentDto = await _studentService.GetStudentByIdAsync(id);
            return Ok(studentDto);
        }
    }
}
