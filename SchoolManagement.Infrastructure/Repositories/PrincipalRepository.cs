using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Exceptions;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Domain.Models.Enums;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class PrincipalRepository : IPrincipalRepository
    {
        private readonly SchoolDbContext _context;
        public PrincipalRepository(SchoolDbContext context)
        {
            _context = context;
        }

        /*----------------Assign the Teacher to the Principal----------------------*/
        public async Task AssignTeacherToPrincipalAsync(int id, PrincipalTeacher teacherAdd)
        {
            var principal = await _context.Principals
                .FirstOrDefaultAsync(s => s.Id == id); 
            if (principal == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundPrincipal);
            }

            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(s => s.Id == teacherAdd.TeacherId);
            if (teacher == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundTeacher);

            }

            var check = await _context.PrincipalTeachers
                .FirstOrDefaultAsync(s => s.PrincipalId == id && s.TeacherId == teacherAdd.TeacherId);

            if (check != null)
            {
                throw new ArgumentException("Teacher was assigned to Principal.");
            }

            var principalTeacher = new PrincipalTeacher
            {
                TeacherId = teacherAdd.TeacherId,
                PrincipalId = id
            };

            _context.PrincipalTeachers.Add(principalTeacher);
            await _context.SaveChangesAsync();
        }

        /*---------------------Create the new principal in Repository---------------*/
        public async Task<Principal> CreatePrincipalAsync(Principal principal)
        {
            _context.Principals.Add(principal);
            await _context.SaveChangesAsync();

            return principal;
        }

        /*--------------------Delete the principal in Repository----------------------*/
        public async Task DeletePrincipalAsync(int id)
        {
            var principal = await _context.Principals
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (principal == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundPrincipal);
            }

            if (principal.Account != null)
            {
                _context.PrincipalAccounts.Remove(principal.Account);
            }

            _context.Principals.Remove(principal);
            await _context.SaveChangesAsync();
        }

        /*------------------Get the principal by Id-------------------------------*/
        public async Task<Principal> GetPrincipalByIdAsync(int id)
        {

            var principal = await _context.Principals
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (principal == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundPrincipal);
            }

            return principal;
        }

        /*------------Get the principal by Id with list teacher in Repository---------------*/
        public async Task<Principal> GetPrincipalByIdTeachersAsync(int id)
        {
            var principal = await _context.Principals
                .Include(s => s.Teachers)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (principal == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundPrincipal);
            }

            return principal;
        }

        /*------------------Get the number of principal in Repository-------------------*/
        public async Task<(int totalPrincipals, int activePrincipals, int notActivePrincipals)> GetPrincipalNumbersAsync()
        {
            var totalPrincipals = await _context.Principals.CountAsync();
            if (totalPrincipals == 0)
            {
                throw new NotFoundException("No principal found in Database.");
            }

            var principalStatus = await _context.Principals
                .GroupBy(s => s.IsActive)
                .Select(g => new
                {
                    IsActive = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            var activePrincipals = principalStatus.FirstOrDefault(g => g.IsActive)?.Count ?? 0;
            var notActivePrincipals = principalStatus.FirstOrDefault(g => !g.IsActive)?.Count ?? 0;

            return (totalPrincipals, activePrincipals, notActivePrincipals);
        }

        /*----------------Get the principal that is active in Repository------------------*/
        public async Task<List<Principal>> GetPrincipalsAsync(int page, int pageSize)
        {
            var principals = await _context.Principals
                .Where(s => s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return principals;
        }

        /*---------------Get the principal that is inactive in Repository-----------------*/
        public async Task<List<Principal>> GetPrincipalsNotActiveAsync(int page, int pageSize)
        {
            var principals = await _context.Principals
                .Where(s => !s.IsActive)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return principals;
        }

        /*-----------------Update the principal account in Repository---------------------*/
        public async Task UpdatePrincipalAccountAsync(int principalId, PrincipalAccount account)
        {
            var existingPrincipal = await _context.Principals
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.Id == principalId);

            if (existingPrincipal == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundPrincipal);
            }

            if (existingPrincipal.Account is null)
            {
                throw new NotFoundException("Account not exist.");
            }

            existingPrincipal.Account.UserName = account.UserName;
            existingPrincipal.Account.Password = account.Password;
            await _context.SaveChangesAsync();
        }

        /*------------------Update the principal------------------------------*/
        public async Task UpdatePrincipalAsync(int Id, Principal principal)
        {
            var existingPrincipal = await _context.Principals
                .FirstOrDefaultAsync(s => s.Id == Id);
            if (existingPrincipal == null)
            {
                throw new NotFoundException(ErrorCode.NotFoundPrincipal);
            }

            existingPrincipal.Email = principal.Email;
            existingPrincipal.DateOfBirth = principal.DateOfBirth;
            existingPrincipal.Name = principal.Name;
            existingPrincipal.IsActive = principal.IsActive;
            existingPrincipal.HomeTown = principal.HomeTown;
            await _context.SaveChangesAsync();
        }
    }
}
