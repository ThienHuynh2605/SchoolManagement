using AutoMapper;
using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Application.Supports.Paginations;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Exceptions;
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

        public async Task<PaginationGrade<GetGradesDto>> GetGradesAsync (int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var grades = await _gradeRepository.GetGradeAsync(page, pageSize);
            var totalGrade = grades.totalGrade;
            var totalPages = (int)Math.Ceiling((decimal)totalGrade / pageSize);

            var gardeDtos = _mapper.Map<List<GetGradesDto>>(grades.grades);

            return new PaginationGrade<GetGradesDto>
            {
                TotalGrade = totalGrade,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                Grades = gardeDtos
            };
        }

        public async Task<PaginationGradeDetail> GetGradeDetailAsync(int id, int page, int pageSize)
        {
            var grade = await _gradeRepository.GetGradeDetailAsync (id);

            var totalStudents = grade.Students?.Count() ?? 0;
            var totalPages = (int)Math.Ceiling(totalStudents / (double)pageSize);

            var students = grade.Students?
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var studentDtos = _mapper.Map<List<StudentInGradeDto>>(students);
            var gradeDto = _mapper.Map<GetGradeDetail>(grade);
            gradeDto.Students = studentDtos;

            return new PaginationGradeDetail
            {
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                TotalStudent = totalStudents,
                Grade = gradeDto
            };
        }

        public async Task<UpdateGradeDto> UpdateGradeAsync(int id, UpdateGradeDto updateGradeDto)
        {
            var grade = _mapper.Map<Grade> (updateGradeDto);
            var updateGrade = await _gradeRepository.UpdateGradeAsync(id, grade);
            return _mapper.Map<UpdateGradeDto>(updateGrade);
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            return await  _gradeRepository.DeleteGradeAsync(id);
        }

        public async Task<UpdateGradeDto> UpdateGradePartialAsync(int id, UpdateGradeDto updateGradeDto)
        {
            var existingGrade = await _gradeRepository.GetGradeDetailAsync(id);
            if (updateGradeDto.IsActive.HasValue)
            {
                existingGrade.IsActive = updateGradeDto.IsActive.Value;
            }
            else
            {
                existingGrade.IsActive = existingGrade.IsActive;
            }

            var grade = _mapper.Map<Grade>(updateGradeDto);
            var updateGrade = await _gradeRepository.UpdateGradePartialAsync (id, grade);

            return _mapper.Map<UpdateGradeDto>(updateGrade);
        }
    }
}
