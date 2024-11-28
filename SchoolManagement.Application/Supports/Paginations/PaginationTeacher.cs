namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationTeacher<T> : PaginationBase
    {
        public int TotalTeachers { get; set; }
        public List<T>? Teachers { get; set; }
    }
}
