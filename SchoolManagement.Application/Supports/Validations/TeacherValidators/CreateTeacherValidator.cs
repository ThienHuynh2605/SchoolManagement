using FluentValidation;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.Supports.Validations.StudentValidators;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.TeacherValidators
{
    public class CreateTeacherValidator : PeopleBaseValidator<CreateTeacherDto>
    {
        private readonly SchoolDbContext _context;
        public CreateTeacherValidator(SchoolDbContext context)
        {
            _context = context;
            RuleFor(s => s.SubjectId)
                .NotEmpty().WithMessage("SubjectId is required.");

            RuleFor(s => s.Account)
                .SetValidator(new TeacherAccountValidator(_context));
        }
    }
}
