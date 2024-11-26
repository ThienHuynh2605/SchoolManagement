namespace SchoolManagement.Domain.Entities
{
    public class PeopleEntity : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? HomeTown { get; set; }
    }
}
