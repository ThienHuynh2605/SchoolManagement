using SchoolManagement.Application.DTOs.GradeDtos;

namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationGradeDetail : PaginationBase
    {
        public int TotalStudent { get; set; }
        public GetGradeDetail? Grade {  get; set; }
    }
}
