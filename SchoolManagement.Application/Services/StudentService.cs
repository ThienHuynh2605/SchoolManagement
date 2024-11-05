using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Interfaces.IServices;
using SchoolManagement.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new NotFoundException("Student not found.");
            }
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var students = await _studentRepository.GetStudentsAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }
    }
}
