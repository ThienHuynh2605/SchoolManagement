using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.Supports.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.IServices
{
    public interface IGradeService
    {
        Task<GradeDto> CreateGradeAsync(GradeDto gradeDto);
        Task<PaginationGrade<GetGradesDto>> GetGradesAsync(int page, int pageSize);
    }
}
