using FluentValidation;
using SchoolManagement.Application.DTOs.GradeDtos;

namespace SchoolManagement.Application.Supports.Validations.GradeValidators
{
    public class CreateGradeValidator : AbstractValidator<GradeDto>
    {
        public CreateGradeValidator()
        {
            RuleFor(s => s.TeacherId)
                .NotEmpty().WithMessage("TeacherId is required.");

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(s => s.Classroom)
                .NotEmpty().WithMessage("Classroom is required.");
        }
    }
}
