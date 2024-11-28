namespace SchoolManagement.Application.DTOs.GradeDtos
{
    public class GetGradesDto : GradeDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
