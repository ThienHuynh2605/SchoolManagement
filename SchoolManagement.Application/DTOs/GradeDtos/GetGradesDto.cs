using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.GradeDtos
{
    public class GetGradesDto : GradeDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
