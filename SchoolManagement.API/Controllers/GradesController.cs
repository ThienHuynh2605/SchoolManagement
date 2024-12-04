using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.IServices;

namespace SchoolManagement.API.Controllers
{
    [Route("api/grades"), Authorize]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        /// <summary>
        /// Create a new grade
        /// </summary>
        /// <param name="gradeDto"></param>
        /// <returns></returns>
        /*-----------------------Endpoint to Create the new grade----------------------*/
        [HttpPost]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> CreateGradeAsync(GradeDto gradeDto)
        {
            var createGrade = await _gradeService.CreateGradeAsync(gradeDto);
            return Ok(createGrade);
        }

        /*----------------------Endpoint to Get the grade-----------------------------*/
        [HttpGet]
        public async Task<IActionResult> GetGradesAsync(int page = 1, int pageSize = 5)
        {
            var getGrade = await _gradeService.GetGradesAsync(page, pageSize);
            return Ok(getGrade);
        }

        /*--------------------Endpoint to Get the grade detail------------------------*/
        [HttpGet("{id}")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> GetGradeDetailAsync(int id, int page = 1, int pageSize = 5)
        {
            var getGradeDetail = await _gradeService.GetGradeDetailAsync(id, page, pageSize);
            return Ok(getGradeDetail);
        }

        /*---------------------Endpoint to Update the grade----------------------------*/
        [HttpPut("{id}")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> UpdateGradeAsync(int id, UpdateGradeDto gradeDto)
        {
            var updateGrade = await _gradeService.UpdateGradeAsync(id, gradeDto);
            return Ok(updateGrade);
        }

        /*--------------------Endpoint to Update the grade partial-----------------------*/
        [HttpPatch("{id}")]
        [Authorize(Policy = "TeacherAndPrincipal")]
        public async Task<IActionResult> UpdateGradePartialAsync(int id, UpdateGradeDto gradeDto)
        {
            var updateGradePartial = await _gradeService.UpdateGradePartialAsync(id, gradeDto);
            return Ok(updateGradePartial);
        }

        /*-------------------Endpoint to Delete the grade--------------------------------*/
        [HttpDelete("{id}")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> DeleteGradeAsync(int id)
        {
            var deleteGrade = await _gradeService.DeleteGradeAsync(id);
            return Ok(deleteGrade);
        }
    }
}
