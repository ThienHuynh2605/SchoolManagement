using AutoMapper;
using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Supports.Mappers
{
    public class StudentMapping : Profile
    {
        public StudentMapping()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, GetStudentDto>();
            CreateMap<Student, GetStudentIdDto>().ReverseMap();
            CreateMap<CreateStudentDto, Student>().ReverseMap();

            CreateMap<StudentAccountDto, StudentAccount>().ReverseMap();
            CreateMap<UpdateStudentDto, Student>().ReverseMap();
            CreateMap<UpdateStudentPartialDto, Student>();

            CreateMap<Student, StudentInGradeDto>().ReverseMap();
            CreateMap<StudentSubject, AssignSubjectDto>().ReverseMap();
        }
    }
}
