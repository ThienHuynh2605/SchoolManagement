using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.IRepositories
{
    public interface IPrincipalRepository
    {
        Task<Principal> CreatePrincipalAsync(Principal principal);
        Task<List<Principal>> GetPrincipalsAsync(int page, int pageSize);
        Task<List<Principal>> GetPrincipalsNotActiveAsync(int page, int pageSize);
        Task<(int totalPrincipals, int activePrincipals, int notActivePrincipals)> GetPrincipalNumbersAsync();
        Task<Principal> GetPrincipalByIdAsync(int id);
        Task UpdatePrincipalAsync(int Id, Principal principal);
        Task UpdatePrincipalAccountAsync(int principalId, PrincipalAccount account);
        Task DeletePrincipalAsync(int id);
        Task<Principal> GetPrincipalByIdTeachersAsync(int id);
        Task AssignTeacherToPrincipalAsync(int id, PrincipalTeacher teacherAdd);

    }
}
