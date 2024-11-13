using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Grade : BaseEntity
    {
        public string? Name { get; set; }
        public string? Classroom { get; set; }

        public List<Student>? Students { get; set; }
    }
}
