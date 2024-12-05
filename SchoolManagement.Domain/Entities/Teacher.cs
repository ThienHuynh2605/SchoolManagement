using SchoolManagement.Domain.Entities.Base;

namespace SchoolManagement.Domain.Entities
{
    public class Teacher : PeopleEntity
    {
        public TeacherAccount? Account { get; set; }
        public List<Grade>? Grades { get; set; }
        public Subject? Subject { get; set; }
        public int? SubjectId { get; set; }
        public List<Principal>? Principals { get; set; }
    }
}
