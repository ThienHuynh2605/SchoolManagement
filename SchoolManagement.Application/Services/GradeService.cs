using AutoMapper;
using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        public GradeService(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }
        public async Task<GradeDto> CreateGradeAsync(GradeDto gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            var createGrade = await _gradeRepository.CreateGradeAsync(grade);

            return _mapper.Map<GradeDto>(createGrade);
        }
    }
}
