using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class StudentAccount : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public Student? Student { get; set; }
        public int StudentId { get; set; }
    }
}
