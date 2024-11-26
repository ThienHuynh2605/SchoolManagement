namespace SchoolManagement.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
