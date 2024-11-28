using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;

namespace SchoolManagement.Application.DTOs.TeacherDtos
{
    public class GetTeacherDto : TeacherDto
    {
        public int Id { get; set; }
        public List<GradeDto>? Grades { get; set; }
        public SubjectDto?  Subject { get; set; }
    }
}
