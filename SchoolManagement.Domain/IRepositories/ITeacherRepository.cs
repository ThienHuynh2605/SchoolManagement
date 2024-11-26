using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.IRepositories
{
    public interface ITeacherRepository
    {
        Task<Teacher> CreateTeacherAsync(Teacher teacher);
        Task<List<Teacher>> GetTeachersAsync(int page, int pageSize);
        Task<List<Teacher>> GetTeachersNotActiveAsync(int page, int pageSize);
        Task<(int totalTeachers, int activeTeachers, int notActiveTeachers)> GetTeacherNumbersAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task<Teacher> UpdateTeacherAsync(int Id, Teacher teacher);
        Task<Teacher> UpdateTeacherPartialAsync(int Id, Teacher teacher);
        Task<TeacherAccount> UpdateTeacherAccountAsync(int teacherId, TeacherAccount account);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
