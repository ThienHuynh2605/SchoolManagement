using AutoMapper;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Supports.Mappers
{
    public class SubjectMapping : Profile
    {
        public SubjectMapping()
        {
            CreateMap<Subject, CreateSubjectDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, UpdateSubjectDto>().ReverseMap();
            CreateMap<DisplaySubjectDto, Subject>().ReverseMap();
            CreateMap<StudentSubject, AssignStudentDto>().ReverseMap();
        }
    }
}
