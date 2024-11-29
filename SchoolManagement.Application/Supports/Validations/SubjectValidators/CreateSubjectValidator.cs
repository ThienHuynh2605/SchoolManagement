using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.SubjectDtos;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.SubjectValidators
{
    public class CreateSubjectValidator : AbstractValidator<CreateSubjectDto>
    {
        private readonly SchoolDbContext _context;
        public CreateSubjectValidator(SchoolDbContext context)
        {
            _context = context;
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Must(BeUniqueUsername).WithMessage("Subject already exists.");
        }

        private bool BeUniqueUsername(string name)
        {
            return !_context.Subjects
                .Any(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
