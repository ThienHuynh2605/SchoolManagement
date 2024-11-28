namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationSubject<T> : PaginationBase
    {
        public int TotalSubject { get; set; }
        public List<T>? Subjects { get; set; }
    }
}
