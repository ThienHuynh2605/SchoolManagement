using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolDbContext _context;
        public GradeRepository(SchoolDbContext context)
        {
            _context = context;
        }

        // Create the grade to Db
        public async Task<Grade> CreateGradeAsync(Grade grade)
        {
            var teacherId = await _context.Teachers
                .FirstOrDefaultAsync(t => t.Id == grade.TeacherId);
            if (teacherId == null)
            {
                throw new NotFoundException("Student not found.");
            }
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        // Get grades in Db
        public async Task<(List<Grade> grades, int totalGrade)> GetGradeAsync(int page, int pageSize)
        {
            var grades = await _context.Grades
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalGrade = await _context.Grades.CountAsync();
            return (grades, totalGrade);
        }

        // Get Grade detail in Db
        public async Task<Grade> GetGradeDetailAsync(int id)
        {
            var grade = await _context.Grades
                .Include(g => g.Students)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (grade == null)
            {
                throw new NotFoundException("Grade not found.");
            }

            return grade;
        }

        // Update grade in Db
        public async Task<Grade> UpdateGradeAsync(int id, Grade grade)
        {
            var teacherId = await _context.Teachers
                .FirstOrDefaultAsync(t => t.Id == grade.TeacherId);
            if (teacherId == null)
            {
                throw new NotFoundException("Student not found.");
            }

            var existingGrade = await _context.Grades
                .FirstOrDefaultAsync(s => s.Id == id);
            if (existingGrade == null)
            {
                throw new NotFoundException("Grade not found.");
            }

            existingGrade.Name = grade.Name;
            existingGrade.Classroom = grade.Classroom;
            existingGrade.IsActive = grade.IsActive;
            existingGrade.TeacherId = grade.TeacherId;
            await _context.SaveChangesAsync();

            return existingGrade;
        }

        // Update grade partial in Db
        public async Task<Grade> UpdateGradePartialAsync(int id, Grade grade)
        {
            var existingGrade = await _context.Grades
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existingGrade == null)
            {
                throw new NotFoundException("Grade not found");
            }

            if (grade.Name != null)
            {
                existingGrade.Name = grade.Name;
            }

            if(grade.Classroom != null)
            {
                existingGrade.Classroom = grade.Classroom;
            }

            if (grade.TeacherId.HasValue)
            {
                var teacher = await _context.Teachers
                    .FirstOrDefaultAsync(s => s.Id == grade.TeacherId.Value);
                if (teacher == null)
                {
                    throw new NotFoundException("Teacher not found");
                }
                existingGrade.TeacherId = grade.TeacherId.Value;   
            }

            await _context.SaveChangesAsync();
            return existingGrade;
        }

        // Delete grade in Db
        public async Task<bool> DeleteGradeAsync(int id)
        {
            var grade = await _context.Grades
                .FirstOrDefaultAsync(s => s.Id==id);

            if (grade == null)
            {
                throw new NotFoundException("Grade not found.");
            }

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
