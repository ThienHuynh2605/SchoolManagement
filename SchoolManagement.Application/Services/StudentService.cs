using AutoMapper;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.Supports.Paginations;
using SchoolManagement.Domain.Entities;
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

        // Get Student with "IsActive == True" from Repository
        public async Task<PaginationStudent<GetStudentDto>> GetStudentsAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var students = await _studentRepository.GetStudentsAsync(page, pageSize);

            var result = await _studentRepository.GetStudentNumbersAsync();
            var totalStudent = result.activeStudents;
            var totalPages = (int)Math.Ceiling((decimal)totalStudent / pageSize);

            var studentDtos = _mapper.Map<List<GetStudentDto>>(students);
            
            return new PaginationStudent<GetStudentDto>
            {
                TotalStudent = totalStudent,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                Students = studentDtos
            };
        }

        // Get students with "IsAction == False" in the Database through Repository
        public async Task<PaginationStudent<GetStudentDto>> GetStudentsNotActiveAsync(int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var students = await _studentRepository.GetStudentsNotActiveAsync(page, pageSize);

            var result = await _studentRepository.GetStudentNumbersAsync();
            var totalStudent = result.notActiveStudents;
            var totalPages = (int)Math.Ceiling((decimal)totalStudent / pageSize);

            var studentDtos = _mapper.Map<List<GetStudentDto>>(students);

            return new PaginationStudent<GetStudentDto>
            {
                TotalStudent = totalStudent,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                Students = studentDtos
            };
        }

        // Get student number from Repository
        public async Task<StudentNumber> GetStudentNumbersAsync()
        {
            var studentNumber = await _studentRepository.GetStudentNumbersAsync();

            return new StudentNumber
            {
                TotalStudents = studentNumber.totalStudents,
                ActiveStudents = studentNumber.activeStudents,
                NotActiveStudents = studentNumber.notActiveStudents
            };
        }

        // Get Student by Id from Repository
        public async Task<GetStudentIdDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            return _mapper.Map<GetStudentIdDto>(student);
        }

        // Create a new student in the Db through the Repository
        public async Task<CreateStudentDto> CreateStudentAsync(CreateStudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            var createStudent = await _studentRepository.CreateStudentAsync(student);

            //return _mapper.Map<CreateStudentDto>(student);
            return _mapper.Map<CreateStudentDto>(createStudent);
        }

        // Update a student in the Db through the Repository
        public async Task<UpdateStudentDto> UpdateStudentAsync(int Id, UpdateStudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);

            var updateStudent = await _studentRepository.UpdateStudentAsync(Id, student);

            return _mapper.Map<UpdateStudentDto>(updateStudent);
        }

        // Update a student partial in the Db through the Repository
        public async Task<UpdateStudentDto> UpdateStudentPartialAsync(int id, UpdateStudentPartialDto studentDto)
        {
            var findStudent = await _studentRepository.GetStudentByIdAsync(id);
            if (studentDto.IsActive.HasValue)
            {
                findStudent.IsActive = studentDto.IsActive.Value;
            }
            else
            {
                findStudent.IsActive = findStudent.IsActive;
            }
            var student = _mapper.Map<Student>(studentDto);

            var updateStudent = await _studentRepository.UpdateStudentPartialAsync(id, student);

            return _mapper.Map<UpdateStudentDto>(updateStudent);
        }

        // Update a student account in the Db through Repository
        public async Task<StudentAccountDto> UpdateStudentAccountAsync(int studentId, StudentAccountDto accountDto)
        {
            var account = _mapper.Map<StudentAccount>(accountDto);
            var updateStudentAccount = await _studentRepository.UpdateStudentAccountAsync(studentId, account);

            return _mapper.Map<StudentAccountDto>(updateStudentAccount);
        }

        // Delete a student in the Db through the Repository
        public async Task<string> DeleteStudentAsync(int id)
        {
            var deleteStudent = await _studentRepository.DeleteStudentAsync(id);
            if (!deleteStudent)
            {
                throw new NotFoundException("Student not found.");
            }

            return "Successfully";
        }
    }
}
