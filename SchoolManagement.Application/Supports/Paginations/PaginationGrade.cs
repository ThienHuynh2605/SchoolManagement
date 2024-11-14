﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Supports.Paginations
{
    public class PaginationGrade<T> : PaginationBase
    {
        public int TotalGrade { get; set; }
        public List<T>? Grades { get; set; }
    }
}
