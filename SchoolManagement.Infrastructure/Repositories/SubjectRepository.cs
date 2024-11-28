using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolDbContext _context;
        public SubjectRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<List<Subject>> GetSubjectsAsync(int page, int pageSize)
        {
            var subjects = await _context.Subjects
                .Where(s => s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return subjects;
        }

        public async Task<List<Subject>> GetSubjectsNotActiveAsync(int page, int pageSize)
        {
            var subjects = await _context.Subjects
                .Where(s => !s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return subjects;
        }

        public async Task<(int totalSubjects, int activeSubjects, int notActiveSubjects)> GetSubjectNumbersAsync()
        {
            var totalSubjects = await _context.Subjects.CountAsync();
            if (totalSubjects == 0)
            {
                throw new NotFoundException("No subjects found in Database.");
            }

            var subjectStatus = await _context.Subjects
                .GroupBy(s => s.IsActive)
                .Select(g => new
                {
                    IsActive = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            var activeSubjects = subjectStatus.FirstOrDefault(g => g.IsActive)?.Count ?? 0;
            var notActiveSubjects = subjectStatus.FirstOrDefault(g => !g.IsActive)?.Count ?? 0;

            return (totalSubjects, activeSubjects, notActiveSubjects);
        }

        public async Task<Subject> GetSubjectByIdTeachersAsync(int id)
        {
            var subject = await _context.Subjects
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null)
            {
                throw new NotFoundException("Subject not found.");
            }

            return subject;
        }

        public async Task<Subject> GetSubjectByIdStudentsAsync(int id)
        {
            var subject = await _context.Subjects
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null)
            {
                throw new NotFoundException("Subject not found.");
            }

            return subject;
        }

        public async Task<Subject> UpdateSubjectAsync(int Id, Subject subject)
        {
            var existingSubject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == Id);
            if (existingSubject == null)
            {
                throw new NotFoundException("Subject not found.");
            }
            existingSubject.Name = subject.Name;
            existingSubject.IsActive = subject.IsActive;
            await _context.SaveChangesAsync();

            return existingSubject;
        }

        public async Task DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null)
            {
                throw new NotFoundException("Subject not found.");
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task AssignStudentToSubjectAsync(int id, StudentSubject studentAdd)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Id == studentAdd.StudentId);
            if (student == null)
            {
                throw new NotFoundException("Student not found.");
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == id);
            if (subject == null)
            {
                throw new NotFoundException("Subject not found.");

            }

            var check = await _context.StudentSubjects
                .FirstOrDefaultAsync(s => s.StudentId == studentAdd.StudentId && s.SubjectId == id);

            if (check != null)
            {
                throw new ArgumentException("Subject was assigned to Student.");
            }

            var studentSubject = new StudentSubject
            {
                SubjectId = id,
                StudentId = studentAdd.StudentId
            };

            _context.StudentSubjects.Add(studentSubject);
            await _context.SaveChangesAsync();
        }
    }
}
