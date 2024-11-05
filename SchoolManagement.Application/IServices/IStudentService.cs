using SchoolManagement.Application.DTOs;

namespace SchoolManagement.Domain.Interfaces.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
    }
}
