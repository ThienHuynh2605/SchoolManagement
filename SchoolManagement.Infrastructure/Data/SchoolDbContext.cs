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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*-------------------------- Config Student Relationship -------------------------*/
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Account)
                .WithOne(s => s.Student)
                .HasForeignKey<StudentAccount>(s => s.StudentId)
                .IsRequired();

        }
    }
}
