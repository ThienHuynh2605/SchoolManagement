namespace SchoolManagement.Application.DTOs.TeacherDtos
{
    public class CreateTeacherDto : PeopleBaseDto
    {
        public TeacherAccountDto? Account { get; set; }
        public int? SubjectId { get; set; }
    }
}
