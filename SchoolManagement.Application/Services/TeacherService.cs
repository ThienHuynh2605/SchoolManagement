﻿using AutoMapper;
using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Application.Supports.Paginations;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Domain.Models.Enums;

namespace SchoolManagement.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        /*-------------------------Create the new teacher in Service--------------------*/
        public async Task<CreateTeacherDto> CreateTeacherAsync(CreateTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            var createTeacher = await _teacherRepository.CreateTeacherAsync(teacher);

            return _mapper.Map<CreateTeacherDto>(createTeacher);
        }

        /*---------------------Get the list teacher is active in Service--------------------*/
        public async Task<PaginationTeacher<GetTeacherDto>> GetTeachersAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var teachers = await _teacherRepository.GetTeachersAsync(page, pageSize);
            var result = await _teacherRepository.GetTeacherNumbersAsync();

            var totalTeachers = result.totalTeachers;
            var totalPages = (int)Math.Ceiling((decimal)totalTeachers / pageSize);

            var teacherDto = _mapper.Map<List<GetTeacherDto>>(teachers);

            return new PaginationTeacher<GetTeacherDto>
            {
                TotalTeachers = totalTeachers,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Teachers = teacherDto
            };
        }

        /*---------------------Get the list teacher is inactive in Service-------------------*/
        public async Task<PaginationTeacher<GetTeacherDto>> GetTeachersNotActiveAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var teachers = await _teacherRepository.GetTeachersNotActiveAsync(page, pageSize);
            var result = await _teacherRepository.GetTeacherNumbersAsync();

            var totalTeachers = result.notActiveTeachers;
            var totalPages = (int)Math.Ceiling((decimal)totalTeachers / pageSize);

            var teacherDto = _mapper.Map<List<GetTeacherDto>>(teachers);

            return new PaginationTeacher<GetTeacherDto>
            {
                TotalTeachers = totalTeachers,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Teachers = teacherDto
            };
        }

        /*-------------------------Get Student by Id from Repository---------------------*/
        public async Task<GetTeacherIdDto> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teacherRepository.GetTeacherByIdAsync(id);
            return _mapper.Map<GetTeacherIdDto>(teacher);
        }

        /*------------------Update a teacher in the Db through the Repository--------------*/
        public async Task<UpdateTeacherDto> UpdateTeacherAsync(int Id, UpdateTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);

            var updateTeacher = await _teacherRepository.UpdateTeacherAsync(Id, teacher);

            return _mapper.Map<UpdateTeacherDto>(updateTeacher);
        }

        /*-----------------Update a student partial in the Db through the Repository-------*/
        public async Task<UpdateTeacherDto> UpdateTeacherPartialAsync(int id, UpdateTeacherPartialDto teacherDto)
        {
            var findteacher = await _teacherRepository.GetTeacherByIdAsync(id);
            if (teacherDto.IsActive.HasValue)
            {
                findteacher.IsActive = teacherDto.IsActive.Value;
            }
            else
            {
                findteacher.IsActive = findteacher.IsActive;
            }
            var teacher = _mapper.Map<Teacher>(teacherDto);

            var updateTeacher = await _teacherRepository.UpdateTeacherPartialAsync(id, teacher);

            return _mapper.Map<UpdateTeacherDto>(updateTeacher);
        }

        /*-------------------------Get teacher number from Repository-----------------------*/
        public async Task<TeacherNumber> GetTeacherNumbersAsync()
        {
            var teacherNumber = await _teacherRepository.GetTeacherNumbersAsync();

            return new TeacherNumber
            {
                TotalTeachers = teacherNumber.totalTeachers,
                ActiveTeachers = teacherNumber.activeTeachers,
                NotActiveTeachers = teacherNumber.notActiveTeachers
            };
        }

        /*------------------Update a teacher account in the Db through Repository-----------*/
        public async Task<TeacherAccountDto> UpdateTeacherAccountAsync(int teacherId, TeacherAccountDto accountDto)
        {
            var account = _mapper.Map<TeacherAccount>(accountDto);
            var updateTeacherAccount = await _teacherRepository.UpdateTeacherAccountAsync(teacherId, account);

            return _mapper.Map<TeacherAccountDto>(updateTeacherAccount);
        }

        /*----------------Delete a teacher in the Db through the Repository-------------------*/
        public async Task<string> DeleteTeacherAsync(int id)
        {
            var deleteTeacher = await _teacherRepository.DeleteTeacherAsync(id);
            if (!deleteTeacher)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);
            }

            return "Successfully";
        }

        /*----------------Get Teacher by Id with List Principal in Service----------------*/
        public async Task<PaginationPrincipal<GetPrincipalDto>> GetTeacherByIdPrincipalsAsync(int id, int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var teachers = await _teacherRepository.GetTeacherByIdPrincipalsAsync(id);

            var totalPrincipals = teachers.Principals?.Count() ?? 0;
            var totalPages = (int)Math.Ceiling((decimal)totalPrincipals / pageSize);

            var principals = teachers.Principals?
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var principalDtos = _mapper.Map<List<GetPrincipalDto>>(principals);

            return new PaginationPrincipal<GetPrincipalDto>
            {
                TotalPrincipals = totalPrincipals,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                Principals = principalDtos
            };
        }
    }
}
