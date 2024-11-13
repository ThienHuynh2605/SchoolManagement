using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.StudentDtos
{
    public class StudentNumber
    {
        public int TotalStudents { get; set; }
        public int ActiveStudents { get; set; }
        public int NotActiveStudents { get; set; }
    }
}
