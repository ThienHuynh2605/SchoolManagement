namespace SchoolManagement.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public string? Name { get; set; }
        public string? Classroom { get; set; }

        public List<Student>? Students { get; set; }

        public Teacher? Teacher { get; set; }
        public int? TeacherId { get; set; }
    }
}
