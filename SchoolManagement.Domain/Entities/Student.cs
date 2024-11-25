using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? HomeTown { get; set; }

        public StudentAccount? Account { get; set; }
        public Grade? Grade { get; set; }
        public int? GradeId { get; set; }    
    }
}
