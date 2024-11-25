using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.GradeDtos
{
    public class UpdateGradeDto : GradeDto
    {
        public bool? IsActive { get; set; }
    }
}
