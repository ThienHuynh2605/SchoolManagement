using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

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

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        
        public DbSet<Principal> Principals { get; set; }
        public DbSet<PrincipalAccount> PrincipalAccounts { get; set; }
        public DbSet<PrincipalTeacher> PrincipalTeachers { get; set; }

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
                .OnDelete(DeleteBehavior.SetNull);

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
                .OnDelete(DeleteBehavior.SetNull);

            /*-------------------------- Config Subject Relationship -------------------------*/
            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Teachers)
                .WithOne(s => s.Subject)
                .HasForeignKey(s => s.SubjectId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Students)
                .WithMany(s => s.Subjects)
                .UsingEntity<StudentSubject>(
                    l => l.HasOne<Student>().WithMany().HasForeignKey(s => s.StudentId),
                    r => r.HasOne<Subject>().WithMany().HasForeignKey(s => s.SubjectId)
                );

            /*-------------------------- Config Principal Relationship -------------------------*/
            modelBuilder.Entity<Principal>()
                .HasOne(s => s.Account)
                .WithOne(s => s.Principal)
                .HasForeignKey<PrincipalAccount>(s => s.PrincipalId)
                .IsRequired();

            modelBuilder.Entity<Principal>()
                .HasMany(s => s.Teachers)
                .WithMany(s => s.Principals)
                .UsingEntity<PrincipalTeacher>(
                    l => l.HasOne<Teacher>().WithMany().HasForeignKey(s => s.TeacherId),
                    r => r.HasOne<Principal>().WithMany().HasForeignKey(s => s.PrincipalId)
                );

        }
    }
}
