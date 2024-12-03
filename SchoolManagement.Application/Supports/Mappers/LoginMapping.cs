using AutoMapper;
using SchoolManagement.Application.DTOs.LoginDtos;
using SchoolManagement.Domain.Models.LoginModel;

namespace SchoolManagement.Application.Supports.Mappers
{
    public class LoginMapping : Profile
    {
        public LoginMapping()
        {
            CreateMap<Login, LoginDto>().ReverseMap();
        }
    }
}
