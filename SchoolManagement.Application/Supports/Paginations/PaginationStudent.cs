using SchoolManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationStudent<T> : PaginationBase
    {
        public int TotalStudent { get; set; }
        public List<T>? Students { get; set; }
    }
}
