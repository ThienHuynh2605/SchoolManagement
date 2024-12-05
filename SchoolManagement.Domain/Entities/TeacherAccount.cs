using SchoolManagement.Domain.Entities.Base;

namespace SchoolManagement.Domain.Entities
{
    public class TeacherAccount : Account
    {
        public Teacher? Teacher { get; set; }
        public int? TeacherId { get; set; }
    }
}
