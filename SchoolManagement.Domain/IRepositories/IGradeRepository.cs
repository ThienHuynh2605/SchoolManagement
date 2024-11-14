using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.IRepositories
{
    public interface IGradeRepository
    {
        Task<Grade> CreateGradeAsync(Grade grade);
        Task<(List<Grade> grades, int totalGrade)> GetGradeAsync(int page, int pageSize);
        Task<Grade> GetGradeDetailAsync(int id);
    }
}
