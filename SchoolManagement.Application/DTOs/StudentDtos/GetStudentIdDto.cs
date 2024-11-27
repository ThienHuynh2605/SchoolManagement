using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;
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
        public GetGradesDto? Grade { get; set; }
        public StudentAccountDto? Account { get; set; }
        //public List<DisplaySubjectDto>? Subjects { get; set; }
    }
}
