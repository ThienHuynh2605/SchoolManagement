using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;

namespace SchoolManagement.Application.DTOs.TeacherDtos
{
    public class GetTeacherIdDto : PeopleBaseDto
    {
        public int Id { get; set; }
        public TeacherAccountDto? Account { get; set; }
        public List<GradeDto>? Grades { get; set; }
        public SubjectDto? Subject { get; set; }

    }
}
