using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.Supports.Paginations;

namespace SchoolManagement.Application.IServices
{
    public interface ITeacherService
    {
        Task<CreateTeacherDto> CreateTeacherAsync(CreateTeacherDto teacherDto);
        Task<PaginationTeacher<GetTeacherDto>> GetTeachersAsync(int page, int pageSize);
        Task<PaginationTeacher<GetTeacherDto>> GetTeachersNotActiveAsync(int page, int pageSize);
        Task<GetTeacherIdDto> GetTeacherByIdAsync(int id);
        Task<UpdateTeacherDto> UpdateTeacherAsync(int Id, UpdateTeacherDto teacherDto);
        Task<UpdateTeacherDto> UpdateTeacherPartialAsync(int Id, UpdateTeacherPartialDto teacherDto);
        Task<TeacherNumber> GetTeacherNumbersAsync();
        Task<TeacherAccountDto> UpdateTeacherAccountAsync(int teacherId, TeacherAccountDto accountDto);
        Task<string> DeleteTeacherAsync(int id);
    }
}
