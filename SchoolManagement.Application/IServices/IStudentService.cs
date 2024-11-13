using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.Supports.Paginations;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Interfaces.IServices
{
    public interface IStudentService
    {
        Task<PaginationStudent<GetStudentDto>> GetStudentsAsync(int page, int pageSize);
        Task<PaginationStudent<GetStudentDto>> GetStudentsNotActiveAsync(int page, int pageSize);
        Task<StudentNumber> GetStudentNumbersAsync();
        Task<GetStudentIdDto> GetStudentByIdAsync(int id);
        Task<CreateStudentDto> CreateStudentAsync(CreateStudentDto studentDto);
        Task<UpdateStudentDto> UpdateStudentAsync(int Id, UpdateStudentDto studentDto);
        Task<UpdateStudentDto> UpdateStudentPartialAsync(int id, UpdateStudentPartialDto studentDto);
        Task<StudentAccountDto> UpdateStudentAccountAsync(int StudentId, StudentAccountDto accountDto);
        Task<string> DeleteStudentAsync(int id);
    }
}
