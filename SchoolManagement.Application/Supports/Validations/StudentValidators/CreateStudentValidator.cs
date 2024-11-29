using FluentValidation;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.Supports.Validations.StudentValidators;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.StudentValidations
{
    public class CreateStudentValidator : PeopleBaseValidator<CreateStudentDto>
    {
        private readonly SchoolDbContext _context;
        public CreateStudentValidator(SchoolDbContext context)
        {
            _context = context;
            RuleFor(s => s.GradeId)
                .NotEmpty().WithMessage("GradeId is required.");

            RuleFor(s => s.Account)
                .SetValidator(new StudentAccountValidator(_context));
        }
    }
}
