using SchoolManagement.Application.DTOs.GradeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationGradeDetail : PaginationBase
    {
        public int TotalStudent { get; set; }
        public GetGradeDetail? Grade {  get; set; }
    }
}
