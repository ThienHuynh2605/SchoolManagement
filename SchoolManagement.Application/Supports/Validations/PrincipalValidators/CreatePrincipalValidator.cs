using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.Supports.Validations.TeacherValidators;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.PrincipalValidators
{
    public class CreatePrincipalValidator : PeopleBaseValidator<CreatePrincipalDto>
    {
        private readonly SchoolDbContext _context;
        public CreatePrincipalValidator(SchoolDbContext context)
        {
            _context = context;
            RuleFor(s => s.Account)
                .SetValidator(new PrincipalAccountValidator(_context));
        }
    }
}
