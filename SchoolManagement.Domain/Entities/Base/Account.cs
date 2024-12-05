using SchoolManagement.Domain.Models.Enums;

namespace SchoolManagement.Domain.Entities.Base
{
    public class Account : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
