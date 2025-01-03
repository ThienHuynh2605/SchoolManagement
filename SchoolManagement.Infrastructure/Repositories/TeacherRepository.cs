﻿using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Domain.Models.Enums;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _context;
        public TeacherRepository(SchoolDbContext context)
        {
            _context = context;
        }

        /*-------------------------Create the teacher to Db------------------------*/
        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            var subjectId = await _context.Subjects
                .FirstOrDefaultAsync(g => g.Id == teacher.SubjectId);
            if (subjectId == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);
            }
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return teacher;
        }

        /*---------------------Get teachers with "IsActive == true" in Db----------------*/
        public async Task<List<Teacher>> GetTeachersAsync(int page, int pageSize)
        {
            var teachers = await _context.Teachers
                .Include(s => s.Grades)
                .Include(s => s.Subject)
                .Where(s => s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return teachers;
        }

        /*------------------------Get teachers with "IsActive == false" from Db-------------*/
        public async Task<List<Teacher>> GetTeachersNotActiveAsync(int page, int pageSize)
        {
            var teachers = await _context.Teachers
                .Include (s => s.Grades)
                .Include (s => s.Subject)
                .Where(s => !s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return teachers;
        }

        /*-----------------------------Get teacher numbers in Db--------------------------*/
        public async Task<(int totalTeachers, int activeTeachers, int notActiveTeachers)> GetTeacherNumbersAsync()
        {
            var totalTeachers = await _context.Teachers.CountAsync();
            if (totalTeachers == 0)
            {
                throw new NotFoundException("No teachers found in Database.");
            }

            var teacherStatus = await _context.Teachers
                .GroupBy(s => s.IsActive)
                .Select(g => new
                {
                    IsActive = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            var activeTeachers = teacherStatus.FirstOrDefault(g => g.IsActive)?.Count??0;
            var notActiveTeachers = teacherStatus.FirstOrDefault(g => !g.IsActive)?.Count??0;

            return (totalTeachers, activeTeachers, notActiveTeachers);
        }

        /*---------------------------Get teacher by Id from Db---------------------------*/
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers
                .Include(s => s.Account)
                .Include(s => s.Grades)
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (teacher == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);
            }

            return teacher;
        }

        /*-----------------------------Update the teacher from Db------------------------*/
        public async Task<Teacher> UpdateTeacherAsync(int Id, Teacher teacher)
        {
            var existingTeacher = await _context.Teachers
                .FirstOrDefaultAsync(s => s.Id == Id);
            if (existingTeacher == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);
            }

            var existingSubject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == teacher.SubjectId);
            if (existingSubject == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundSubject);
            }

            existingTeacher.Email = teacher.Email;
            existingTeacher.DateOfBirth = teacher.DateOfBirth;
            existingTeacher.Name = teacher.Name;
            existingTeacher.IsActive = teacher.IsActive;
            existingTeacher.HomeTown = teacher.HomeTown;
            existingTeacher.SubjectId = teacher.SubjectId;
            await _context.SaveChangesAsync();

            return existingTeacher;
        }

        /*-------------------------------Update the teacher partial in Db-----------------*/
        public async Task<Teacher> UpdateTeacherPartialAsync(int id, Teacher teacher)
        {
            var existingTeacher = await _context.Teachers
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existingTeacher == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);
            }

            if (!string.IsNullOrEmpty(teacher.Email))
            {
                existingTeacher.Email = teacher.Email;
            }

            if (!string.IsNullOrEmpty(teacher.Name))
            {
                existingTeacher.Name = teacher.Name;
            }

            if (!string.IsNullOrEmpty(teacher.HomeTown))
            {
                existingTeacher.HomeTown = teacher.HomeTown;
            }

            if (teacher.DateOfBirth.HasValue)
            {
                existingTeacher.DateOfBirth = teacher.DateOfBirth.Value;
            }

            if (teacher.SubjectId.HasValue)
            {
                var existingSubject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == teacher.SubjectId);
                if (existingSubject == null)
                {
                    throw new NotFoundException(ErrorCode.NotFoundSubject);
                }

                existingTeacher.SubjectId = teacher.SubjectId.Value;
            }

            await _context.SaveChangesAsync();

            return existingTeacher;
        }

        /*--------------------------Update the teacher account in Db---------------------*/
        public async Task<TeacherAccount> UpdateTeacherAccountAsync(int teacherId, TeacherAccount account)
        {
            var existingTeacher = await _context.Teachers
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id == teacherId);

            if (existingTeacher == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);
            }

            existingTeacher.Account.UserName = account.UserName;
            existingTeacher.Account.Password = account.Password;
            await _context.SaveChangesAsync();

            return existingTeacher.Account;
        }

        /*---------------------------Delete the student in Db--------------------------*/
        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (teacher == null)
            {
                return false;
            }

            if (teacher.Account != null)
            {
                _context.TeacherAccounts.Remove(teacher.Account);
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return true;
        }

        /*-------------------------Get Teacher by Id with List Principal--------------------*/
        public async Task<Teacher> GetTeacherByIdPrincipalsAsync(int id)
        {
            var teacher = await _context.Teachers
               .Include(s => s.Principals)
               .FirstOrDefaultAsync(s => s.Id == id);

            if (teacher == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);
            }

            return teacher;
        }
    }
}
