using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;

namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationStudentSubject : PaginationBase
    {
        public int TotalSubjects { get; set; }
        public List<DisplaySubjectDto>? Subjects { get; set; }
    }
}
