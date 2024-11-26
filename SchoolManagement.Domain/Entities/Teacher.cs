namespace SchoolManagement.Domain.Entities
{
    public class Teacher : PeopleEntity
    {
        public TeacherAccount? Account { get; set; }
        public List<Grade>? Grades { get; set; }
    }
}
