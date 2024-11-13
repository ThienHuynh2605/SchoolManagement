using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.StudentDtos
{
    public class GetStudentIdDto : PeopleBaseDto
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public StudentAccountDto? Account { get; set; }
    }
}
