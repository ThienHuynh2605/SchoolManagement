namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationPrincipal<T> : PaginationBase
    {
        public int TotalPrincipals {  get; set; }
        public List<T>? Principals { get; set; }
    }
}
