using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync(int page, int pageSize);
        Task<List<Student>> GetStudentsNotActiveAsync(int page, int pageSize);
        Task<(int totalStudents, int activeStudents, int notActiveStudents)> GetStudentNumbersAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int Id, Student student);
        Task<Student> UpdateStudentPartialAsync(int id, Student student);
        Task<StudentAccount> UpdateStudentAccountAsync(int studentId, StudentAccount account);
        Task<bool> DeleteStudentAsync(int id);
    }
}
