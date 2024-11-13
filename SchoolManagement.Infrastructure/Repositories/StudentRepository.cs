﻿using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _context;
        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }
        
        // Get Students with "IsActive == True" from Db
        public async Task<List<Student>> GetStudentsAsync(int page, int pageSize)
        {
            var students = await _context.Students
                .Where(s => s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return students; 
        }

        //Get students with "IsActive == false" from Db
        public async Task<List<Student>> GetStudentsNotActiveAsync(int page, int pageSize)
        {
            var students = await _context.Students
                .Where(s => !s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return students;
        }

        // Get Student number from Db
        public async Task<(int totalStudents, int activeStudents, int notActiveStudents)> GetStudentNumbersAsync()
        {
            var totalStudents = await _context.Students.CountAsync();
            if (totalStudents == 0)
            {
                throw new NotFoundException("No students found in Database.");
            }

            var studentStatus = await _context.Students
                .GroupBy(s => s.IsActive)
                .Select(g => new
                {
                    IsActive = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            var activeStudents = studentStatus.FirstOrDefault(g => g.IsActive)?.Count ?? 0;
            var notActiveStudents = studentStatus.FirstOrDefault(g => !g.IsActive)?.Count ?? 0;

            return (totalStudents, activeStudents, notActiveStudents);
        }

        // Get Student by Id from Db
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new NotFoundException("Student not found.");
            }

            return student;
        }

        // Create the new student to Db
        public async Task<Student> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        // Update the student from Db
        public async Task<Student> UpdateStudentAsync(int Id,  Student student)
        {
            var existingStudent = await _context.Students
                .FirstOrDefaultAsync(s => s.Id ==  Id);
            if (existingStudent == null)
            {
                throw new NotFoundException("Student not found.");
            }

            existingStudent.Email = student.Email;
            existingStudent.GradeId = student.GradeId;
            existingStudent.DateOfBirth = student.DateOfBirth;  
            existingStudent.Name = student.Name;
            existingStudent.IsActive = student.IsActive;
            existingStudent.HomeTown = student.HomeTown;
            await _context.SaveChangesAsync();

            return existingStudent;
        }

        // Update the student partial in Db
        public async Task<Student> UpdateStudentPartialAsync(int id, Student student)
        {
            var existingStudent = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existingStudent == null)
            {
                throw new NotFoundException("Student not found.");
            }

            if (!string.IsNullOrEmpty(student.Email))
            {
                existingStudent.Email = student.Email;
            }

            if (!string.IsNullOrEmpty(student.Name))
            {
                existingStudent.Name = student.Name;
            }

            if (!string.IsNullOrEmpty(student.HomeTown))
            {
                existingStudent.HomeTown = student.HomeTown;
            }

            if (student.DateOfBirth.HasValue)
            {
                existingStudent.DateOfBirth = student.DateOfBirth.Value;
            }

            if (student.GradeId != null)
            {
                existingStudent.GradeId = student.GradeId;
            }

#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
            if (student.IsActive != null)
            {
                existingStudent.IsActive = student.IsActive;
            }
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'

            await _context.SaveChangesAsync();

            return existingStudent;
        }

        // Update the student account in Db
        public async Task<StudentAccount> UpdateStudentAccountAsync(int studentId, StudentAccount account)
        {
            var existingStudent = await _context.Students
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id == studentId);

            if (existingStudent == null)
            {
                throw new NotFoundException("Student not found.");
            }

            existingStudent.Account.UserName = account.UserName;
            existingStudent.Account.Password = account.Password;
            await _context.SaveChangesAsync();

            return existingStudent.Account;
        }

        // Delete the student in Db
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id==id);

            if (student == null)
            {
                return false;
            }

            if (student.Account != null)
            {
                _context.StudentAccounts.Remove(student.Account);
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
