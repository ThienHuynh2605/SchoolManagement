using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
        
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var students = new List<Student>();
            var random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                int year = random.Next(2002, 2006);
                int month = random.Next(1, 13);
                int date = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

                var dateOfBirth = new DateTime(year, month, date);

                students.Add(new Student
                {
                    Id = i,
                    Name = $"Student{i}",
                    DateOfBirth = dateOfBirth,
                    Email = $"emailStudent{i}@gmail.com",
                    HomeTown = $"HomeTown{i % 5}"
                });
            }

            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}
