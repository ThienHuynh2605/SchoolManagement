using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.StudentDtos
{
    public class UpdateStudentPartialDto : PeopleBaseDto
    {
        public int? GradeId { get; set; }
    }
}
