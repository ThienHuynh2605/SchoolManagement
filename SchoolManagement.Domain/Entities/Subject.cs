namespace SchoolManagement.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string? Name { get; set; }
        public List<Teacher>? Teachers { get; set; }
        public List<Student>? Students { get; set; }
    }
}
