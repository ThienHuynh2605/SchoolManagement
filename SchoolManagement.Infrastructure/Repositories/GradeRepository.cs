﻿using Microsoft.EntityFrameworkCore;
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
    }
}
