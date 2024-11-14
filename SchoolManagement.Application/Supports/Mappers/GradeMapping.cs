using AutoMapper;
using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Supports.Mappers
{
    public class GradeMapping : Profile
    {
        public GradeMapping()
        {
            CreateMap<Grade, GradeDto>().ReverseMap();
            CreateMap<Grade, GetGradesDto>().ReverseMap();  
        }
    }
}
