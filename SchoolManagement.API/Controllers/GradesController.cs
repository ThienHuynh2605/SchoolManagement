using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Domain.Exceptions;

namespace SchoolManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGradeAsync(GradeDto gradeDto)
        {
             var createGrade = await _gradeService.CreateGradeAsync(gradeDto);
            return Ok(createGrade);
        }

        [HttpGet]
        public async Task<IActionResult> GetGradesAsync(int page = 1, int pageSize = 5)
        {
            var getGrade = await _gradeService.GetGradesAsync(page, pageSize);
            return Ok(getGrade);
        }
    }
}
