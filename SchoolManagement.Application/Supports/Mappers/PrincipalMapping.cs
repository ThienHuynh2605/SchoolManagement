using AutoMapper;
using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Supports.Mappers
{
    public class PrincipalMapping : Profile
    {
        public PrincipalMapping()
        {
            CreateMap<Principal, CreatePrincipalDto>().ReverseMap();
            CreateMap<Principal, GetPrincipalDto>().ReverseMap();
            CreateMap<Principal, GetPrincipalIdDto>().ReverseMap();
            CreateMap<Principal, UpdatePrincipalDto>().ReverseMap();
            CreateMap<PrincipalAccount, PrincipalAccountDto>().ReverseMap();
            CreateMap<PrincipalTeacher, AssignTeacherDto>().ReverseMap();
        }
    }
}
