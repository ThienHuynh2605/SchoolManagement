using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Domain.Interfaces.IServices;

namespace SchoolManagement.API.Controllers
{
    [Route("api/students"), Authorize]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Endpoint to Get all active students with pagination
        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync(int page = 1, int pageSize = 5)
        {
            var studentsDto = await _studentService.GetStudentsAsync(page, pageSize);
            return Ok(studentsDto);
        }

        // Endpoint to Get all not active students with pagination
        [HttpGet("not-active")]
        public async Task<IActionResult> GetStudentsNotActiveAsync(int page = 1, int pageSize = 5)
        {
            var studentsDto = await _studentService.GetStudentsNotActiveAsync(page, pageSize);
            return Ok(studentsDto);
        }

        // Endpoint to Get the student number with detail
        [HttpGet("numbers")]
        public async Task<IActionResult> GetStudentNumberAsync()
        {
            var studentNumber = await _studentService.GetStudentNumbersAsync();
            return Ok(studentNumber);
        }

        // Endpoint to Get the student by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var studentDto = await _studentService.GetStudentByIdAsync(id);
            return Ok(studentDto);
        }

        // Endpoint to Get the student and subject by Id
        [HttpGet("{id}/subjects")]
        public async Task<IActionResult> GetStudentByIdSubjectsAsync(int id, int page = 1, int pageSize = 5)
        {
            var studentDto = await _studentService.GetStudentByIdSubjectsAsync(id, page, pageSize);
            return Ok(studentDto);
        }

        // Endpoint to Create the new student
        [HttpPost]
        public async Task<ActionResult> CreateStudentAsync(CreateStudentDto studentDto)
        {
            var createStudent = await _studentService.CreateStudentAsync(studentDto);
            return Ok(createStudent);
        }

        // Endpoint to Update the student
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, [FromBody] UpdateStudentDto studentDto)
        {
            var updateStudent = await _studentService.UpdateStudentAsync(id, studentDto);
            return Ok(updateStudent);
        }

        // Endpoint to Update the student partial
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStudentPartialAsync(int id, [FromBody] UpdateStudentPartialDto studentDto)
        {
            var updateStudent = await _studentService.UpdateStudentPartialAsync(id, studentDto);
            return Ok(updateStudent);
        }

        // Endpoint to Update the student account
        [HttpPut("{studentId}/account")]
        public async Task<IActionResult> UpdateStudentAccountAsync(int studentId, [FromBody] StudentAccountDto accountDto)
        {
            var updateStudentAccount = await _studentService.UpdateStudentAccountAsync(studentId, accountDto);
            return Ok(updateStudentAccount);
        }

        // Endpoint to Delete the student
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            var deleteStudent = await _studentService.DeleteStudentAsync(id);
            return Ok(deleteStudent);
        }

        [HttpPost("{studentId}/add-subject")]
        public async Task<IActionResult> AssignSubjectToStudentAsync(int studentId, AssignSubjectDto subjectAdd)
        {
            await _studentService.AssignSubjectToStudentAsync(studentId, subjectAdd);
            return Ok("Successfully.");
        }
    }
}
