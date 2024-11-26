namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationTeacher<T> : PaginationBase
    {
        public int TotalTeacher { get; set; }
        public List<T>? Teachers { get; set; }
    }
}
