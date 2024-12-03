using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.Supports.Validations.AccountValidators;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.PrincipalValidators
{
    public class PrincipalAccountValidator : AccountValidator<PrincipalAccountDto>
    {
        public PrincipalAccountValidator(SchoolDbContext context) : base(context)
        {
            
        }
    }
}
