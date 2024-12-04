using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.IServices;

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

        /*------------------Endpoint to create the new principal----------------------*/
        [HttpPost]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> CreatePrincipalAsync([FromBody] CreatePrincipalDto principalDto)
        {
            await _principalService.CreatePrincipalAsync(principalDto);
            return Ok("Successfully.");
        }

        /*------------------Endpoint to get all of the principal--------------------------*/
        [HttpGet("isActive/{isActive}")]
        public async Task<IActionResult> GetPrincipalsAsync(bool isActive, int page = 1, int pageSize = 5)
        {
            var principal = await _principalService.GetPrincipalsAsync(isActive, page, pageSize);
            return Ok(principal);
        }

        /*----------------Endpoint to get the number of principal------------------------*/
        [HttpGet("numbers")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> GetPrincipalNumberAsync()
        {
            var principalNumber = await _principalService.GetPrincipalNumbersAsync();
            return Ok(principalNumber);
        }

        /*-----------------Endpoint to get principal by Id--------------------------*/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrincipalByIdAsync(int id)
        {
            var principalDto = await _principalService.GetPrincipalByIdAsync(id);
            return Ok(principalDto);
        }

        /*------------------Endpoint to Update the principal-----------------------*/
        [HttpPut("{id}")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> UpdatePrincipalAsync(int id, [FromBody] UpdatePrincipalDto principalDto)
        {
            await _principalService.UpdatePrincipalAsync(id, principalDto);
            return Ok("Successfully.");
        }

        /*-------------------Endpoint to Update the principal account-----------------*/
        [HttpPut("{id}/account")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> UpdatePrincipalAccountAsync(int id, [FromBody] PrincipalAccountDto accountDto)
        {
            await _principalService.UpdatePrincipalAccountAsync(id, accountDto);
            return Ok("Successfully.");
        }

        /*------------------Endpoint to Delete the principal------------------------*/
        [HttpDelete("{id}")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> DeletePrincipalAsync(int id)
        {
            await _principalService.DeletePrincipalAsync(id);
            return Ok("Successfully.");
        }

        /*-----------------Endpoint to Get principal by Id with list teacher----------------*/
        [HttpGet("{id}/teachers")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> GetPrincipalByIdTeachersAsync(int id, int page = 1, int pageSize = 5)
        {
            var teachersDto = await _principalService.GetPrincipalByIdTeachersAsync(id, page, pageSize);
            return Ok(teachersDto);
        }

        /*---------------Endpoint to Assign the teacher to the principal------------------*/
        [HttpPost("{principalId}/add-teacher")]
        [Authorize(Policy = "OnlyPrincipal")]
        public async Task<IActionResult> AssignTeacherToPrincipalAsync(int principalId, AssignTeacherDto teacherAdd)
        {
            await _principalService.AssignTeacherToPrincipalAsync(principalId, teacherAdd);
            return Ok("Successfully.");
        }
    }
}
