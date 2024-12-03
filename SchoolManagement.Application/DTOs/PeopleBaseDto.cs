using SchoolManagement.Domain.Models.Enums;

namespace SchoolManagement.Application.DTOs
{
    public class PeopleBaseDto
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? HomeTown { get; set; }
        public bool? IsActive { get; set; }
        public Role? Role { get; set; }
    }
}
