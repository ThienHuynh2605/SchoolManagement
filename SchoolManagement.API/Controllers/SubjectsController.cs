using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Application.IServices;

namespace SchoolManagement.API.Controllers
{
    [Route("api/subjects"), Authorize]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /*--------------Endpoint to Create the new subject----------------------*/
        [HttpPost]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> CreateSubjectAsync([FromBody] CreateSubjectDto subjectDto)
        {
            await _subjectService.CreateSubjectAsync(subjectDto);
            return Ok("Successfully.");
        }

        /*---------------Endpoint to Get the subject that is active------------------*/
        [HttpGet]
        public async Task<IActionResult> GetSubjectsAsync(int page = 1, int pageSize = 5)
        {
            var subject = await _subjectService.GetSubjectsAsync(page, pageSize);
            return Ok(subject);
        }

        /*--------------Endpoint to Get the subject that is inactive----------------*/
        [HttpGet("not-active")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> GetSubjectsNotActiveAsync(int page = 1, int pageSize = 5)
        {
            var subject = await _subjectService.GetSubjectsNotActiveAsync(page, pageSize);
            return Ok(subject);
        }

        /*--------------------Endpoint to Get the number of subject------------------*/
        [HttpGet("numbers")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> GetSubjectNumberAsync()
        {
            var subjectNumber = await _subjectService.GetSubjectNumbersAsync();
            return Ok(subjectNumber);
        }

        /*----------------Endpoint to Get the subject by Id with list Teacher----------------*/
        [HttpGet("{id}/teachers")]
        public async Task<IActionResult> GetSubjectIdTeachersAsync(int id, int page = 1, int pageSize = 5)
        {
            var subjects = await _subjectService.GetSubjectByIdTeachersAsync(id, page, pageSize);
            return Ok(subjects);
        }

        /*----------------Endpoint to Get the subject by Id with list student----------------*/
        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetSubjectIdStudentsAsync(int id, int page = 1, int pageSize = 5)
        {
            var subjects = await _subjectService.GetSubjectByIdStudentsAsync(id, page, pageSize);
            return Ok(subjects);
        }

        /*-----------------Endpoint to Update the subject-----------------------------*/
        [HttpPut("{id}")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> UpdateSubjectAsync(int id, [FromBody] UpdateSubjectDto subjectDto)
        {
            await _subjectService.UpdateSubjectAsync(id, subjectDto);
            return Ok("Successfully.");
        }

        /*------------------Endpoint to Delete the subject----------------------------*/
        [HttpDelete("{id}")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> DeleteSubjectAsync(int id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return Ok("Successfully.");
        }

        /*-------------------Endpoint to Assign the student to the subject------------------*/
        [HttpPost("{subjectId}/add-student")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> AssignStudentToSubjectAsync(int subjectId, AssignStudentDto studentAdd)
        {
            await _subjectService.AssignStudentToSubjectAsync(subjectId, studentAdd);
            return Ok("Successfully.");
        }
    }
}
