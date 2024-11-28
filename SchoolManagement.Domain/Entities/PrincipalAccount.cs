namespace SchoolManagement.Domain.Entities
{
    public class PrincipalAccount : Account
    {
        public Principal? Principal { get; set; }
        public int? PrincipalId { get; set; }
    }
}
