using SchoolManagement.Domain.Models.Enums;

namespace SchoolManagement.Domain.Entities.Base
{
    public class PeopleEntity : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? HomeTown { get; set; }
        public Role? Role { get; set; }
    }
}
