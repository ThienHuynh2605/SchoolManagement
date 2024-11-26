using SchoolManagement.Application.DTOs.GradeDtos;

namespace SchoolManagement.Application.DTOs.TeacherDtos
{
    public class GetTeacherDto : PeopleBaseDto
    {
        public List<GradeDto>? Grades { get; set; }
    }
}
