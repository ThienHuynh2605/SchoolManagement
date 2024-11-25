using SchoolManagement.Application.DTOs.GradeDtos;
using SchoolManagement.Application.Supports.Paginations;

namespace SchoolManagement.Application.IServices
{
    public interface IGradeService
    {
        Task<GradeDto> CreateGradeAsync(GradeDto gradeDto);
        Task<PaginationGrade<GetGradesDto>> GetGradesAsync(int page, int pageSize);
        Task<PaginationGradeDetail> GetGradeDetailAsync(int id, int page, int pageSize);
        Task<UpdateGradeDto> UpdateGradeAsync(int id, UpdateGradeDto updateGradeDto);
        Task<UpdateGradeDto> UpdateGradePartialAsync(int id, UpdateGradeDto updateGradeDto);
        Task<bool> DeleteGradeAsync(int id);
    }
}
