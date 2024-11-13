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
    }
}
