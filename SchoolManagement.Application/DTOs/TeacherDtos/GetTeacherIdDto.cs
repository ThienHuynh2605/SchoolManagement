using SchoolManagement.Application.DTOs.GradeDtos;

namespace SchoolManagement.Application.DTOs.TeacherDtos
{
    public class GetTeacherIdDto : PeopleBaseDto
    {
        public int Id { get; set; }
        public TeacherAccountDto? Account { get; set; }
        public List<GradeDto>? Grades { get; set; }

    }
}
