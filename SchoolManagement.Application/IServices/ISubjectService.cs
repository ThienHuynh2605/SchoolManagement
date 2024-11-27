using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.Supports.Paginations;

namespace SchoolManagement.Application.IServices
{
    public interface ISubjectService
    {
        Task CreateSubjectAsync(CreateSubjectDto subjectDto);
        Task<PaginationSubject<SubjectDto>> GetSubjectsAsync(int page, int pageSize);
        Task<PaginationSubject<SubjectDto>> GetSubjectsNotActiveAsync(int page, int pageSize);
        Task<SubjectNumber> GetSubjectNumbersAsync();
        Task<PaginationSubjectTeacher> GetSubjectByIdTeachersAsync(int id, int page, int pageSize);
        Task<PaginationSubjectStudent> GetSubjectByIdStudentsAsync(int id, int page, int pageSize);
        Task UpdateSubjectAsync(int Id, UpdateSubjectDto subjectDto);
        Task DeleteSubjectAsync(int Id);
    }
}
