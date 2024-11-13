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

        }
    }
}
