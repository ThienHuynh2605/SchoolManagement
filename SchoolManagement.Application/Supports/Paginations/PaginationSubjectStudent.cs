using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;

namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationSubjectStudent : PaginationBase
    {
        public int TotalStudents { get; set; }
        public SubjectDto? Subject { get; set; }
        public List<StudentDto>? Students { get; set; }
    }
}
