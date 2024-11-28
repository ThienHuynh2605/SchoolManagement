namespace SchoolManagement.Application.DTOs.PrincipalDtos
{
    public class GetPrincipalIdDto : PrincipalDto
    {
        public int Id { get; set; }
        public PrincipalAccountDto? Account { get; set; }
    }
}
