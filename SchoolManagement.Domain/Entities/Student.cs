using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SchoolManagement.Domain.Entities.Base;

namespace SchoolManagement.Domain.Entities
{
    public class Student : PeopleEntity
    {
        public StudentAccount? Account { get; set; }
        public Grade? Grade { get; set; }
        public int? GradeId { get; set; }   
        public List<Subject>? Subjects { get; set; }
    }
}
