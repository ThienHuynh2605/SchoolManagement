﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Application.Supports.Paginations;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.IRepositories;
using System.Diagnostics;

namespace SchoolManagement.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task CreateSubjectAsync(CreateSubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);

            var createSubject = await _subjectRepository.CreateSubjectAsync(subject);
        }

        public async Task<PaginationSubject<SubjectDto>> GetSubjectsAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var subjects = await _subjectRepository.GetSubjectsAsync(page, pageSize);
            var result = await _subjectRepository.GetSubjectNumbersAsync();

            var totalSubjects = result.totalSubjects;
            var totalPages = (int)Math.Ceiling((decimal)totalSubjects / pageSize);

            var subjectDto = _mapper.Map<List<SubjectDto>>(subjects);

            return new PaginationSubject<SubjectDto>
            {
                TotalSubject = totalSubjects,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Subjects = subjectDto
            };
        }

        public async Task<PaginationSubject<SubjectDto>> GetSubjectsNotActiveAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var subjects = await _subjectRepository.GetSubjectsNotActiveAsync(page, pageSize);
            var result = await _subjectRepository.GetSubjectNumbersAsync();

            var totalSubjects = result.totalSubjects;
            var totalPages = (int)Math.Ceiling((decimal)totalSubjects / pageSize);

            var subjectDto = _mapper.Map<List<SubjectDto>>(subjects);

            return new PaginationSubject<SubjectDto>
            {
                TotalSubject = totalSubjects,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Subjects = subjectDto
            };
        }

        public async Task<SubjectNumber> GetSubjectNumbersAsync()
        {
            var subjectNumber = await _subjectRepository.GetSubjectNumbersAsync();

            return new SubjectNumber
            {
                TotalSubjects = subjectNumber.totalSubjects,
                ActiveSubjects = subjectNumber.activeSubjects,
                NotActiveSubjects = subjectNumber.notActiveSubjects
            };
        }

        public async Task<PaginationSubjectTeacher> GetSubjectByIdTeachersAsync(int id, int page, int pageSize)
        {
            var subject = await _subjectRepository.GetSubjectByIdTeachersAsync(id);

            var totalTeachers = subject.Teachers?.Count() ?? 0;
            var totalPages = (int)Math.Ceiling(totalTeachers / (double)pageSize);

            var teachers = subject.Teachers?
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var teacherDtos = _mapper.Map<List<TeacherDto>>(teachers);
            var subjectDto = _mapper.Map<SubjectDto>(subject);

            return new PaginationSubjectTeacher
            {
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                TotalTeachers = totalTeachers,
                Subject = subjectDto,
                Teachers = teacherDtos
            };
        }

        public async Task<PaginationSubjectStudent> GetSubjectByIdStudentsAsync(int id, int page, int pageSize)
        {
            var subject = await _subjectRepository.GetSubjectByIdStudentsAsync(id);

            var totalStudents = subject.Students?.Count() ?? 0;
            var totalPages = (int)Math.Ceiling(totalStudents / (double)pageSize);

            var students = subject.Students?
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var studentDtos = _mapper.Map<List<StudentDto>>(students);
            var subjectDto = _mapper.Map<SubjectDto>(subject);

            return new PaginationSubjectStudent
            {
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                TotalStudents = totalStudents,
                Subject = subjectDto,
                Students = studentDtos
            };
        }

        public async Task UpdateSubjectAsync(int Id, UpdateSubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);

            await _subjectRepository.UpdateSubjectAsync(Id, subject);
        }

        public async Task DeleteSubjectAsync(int Id)
        {
            await _subjectRepository.DeleteSubjectAsync(Id);
        }
    }
}