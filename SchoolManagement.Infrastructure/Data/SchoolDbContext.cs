using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Models.Enums;
using SchoolManagement.Domain.Models.Loging;
using System.Security.Claims;

namespace SchoolManagement.Infrastructure.Data
{
    public class SchoolDbContext : DbContext
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _contextAccessor = httpContextAccessor;
        }
        
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
        
        public DbSet<Audit> Audits { get; set; }

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

        /*============================Change tracking================================*/
        public virtual async Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                auditEntry.Name = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                Audits.Add(auditEntry.ToAudit());
            }
            return await base.SaveChangesAsync(); 
        }
    }
}
