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
        public DbSet<StudentAccount> StudentAccounts { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAccount> TeacherAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*-------------------------- Config Student Relationship -------------------------*/
            // One-to-One Relationship 
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Account)
                .WithOne(s => s.Student)
                .HasForeignKey<StudentAccount>(s => s.StudentId)
                .IsRequired();

            // One-to-Many Relationship
            modelBuilder.Entity<Grade>()
                .HasMany(s => s.Students)
                .WithOne(s => s.Grade)
                .HasForeignKey(s => s.GradeId)
                .IsRequired();

            /*-------------------------- Config Teacher Relationship -------------------------*/
            modelBuilder.Entity<Teacher>()
                .HasOne(s => s.Account)
                .WithOne(s => s.Teacher)
                .HasForeignKey<TeacherAccount>(s => s.TeacherId)
                .IsRequired();

            modelBuilder.Entity<Teacher>()
                .HasMany(s => s.Grades)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId)
                .IsRequired();

        }
    }
}
