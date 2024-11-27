using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.IRepositories
{
    public interface ISubjectRepository
    {
        Task<Subject> CreateSubjectAsync(Subject subject);
        Task<List<Subject>> GetSubjectsAsync(int page, int pageSize);
        Task<List<Subject>> GetSubjectsNotActiveAsync(int page, int pageSize);
        Task<(int totalSubjects, int activeSubjects, int notActiveSubjects)> GetSubjectNumbersAsync();
        Task<Subject> GetSubjectByIdTeachersAsync(int id);
        Task<Subject> GetSubjectByIdStudentsAsync(int id);
        Task<Subject> UpdateSubjectAsync(int Id, Subject subject);
        Task DeleteSubjectAsync(int id);

    }
}
