using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Application.DTOs.TeacherDtos;

namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationSubjectTeacher : PaginationBase
    {
        public int TotalTeachers { get; set; }
        public SubjectDto? Subject { get; set; }
        public List<TeacherDto>? Teachers { get; set; }
    }
}
