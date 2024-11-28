using AutoMapper;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Supports.Mappers
{
    public class TeacherMapping : Profile
    {
        public TeacherMapping()
        {
            CreateMap<Teacher,CreateTeacherDto>().ReverseMap();
            CreateMap<Teacher,GetTeacherDto>().ReverseMap();
            CreateMap<Teacher,GetTeacherIdDto>().ReverseMap();
            CreateMap<Teacher,UpdateTeacherDto>().ReverseMap();
            CreateMap<Teacher,TeacherDto>().ReverseMap();
            CreateMap<Teacher,UpdateTeacherPartialDto>().ReverseMap();
            CreateMap<TeacherAccount,TeacherAccountDto>().ReverseMap();
        }
    }
}
