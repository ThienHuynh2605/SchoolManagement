using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.Supports.Paginations;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.IServices
{
    public interface IPrincipalService
    {
        Task CreatePrincipalAsync(CreatePrincipalDto principalDto);
        Task<PaginationPrincipal<GetPrincipalDto>> GetPrincipalsAsync(bool isActive, int page, int pageSize);
        Task<PrincipalNumber> GetPrincipalNumbersAsync();
        Task<GetPrincipalIdDto> GetPrincipalByIdAsync(int id);
        Task UpdatePrincipalAsync(int Id, UpdatePrincipalDto principalDto);
        Task UpdatePrincipalAccountAsync(int Id, PrincipalAccountDto accountDto);
        Task DeletePrincipalAsync(int id);
        Task<PaginationTeacher<TeacherDto>> GetPrincipalByIdTeachersAsync(int id, int page, int pageSize);
        Task AssignTeacherToPrincipalAsync(int id, AssignTeacherDto teacherAdd);

    }
}
