using FluentValidation;
using SchoolManagement.Application.DTOs.GradeDtos;

namespace SchoolManagement.Application.Supports.Validations.GradeValidators
{
    public class UpdateGradeValidator : AbstractValidator<UpdateGradeDto>
    {
        public UpdateGradeValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(s => s.Classroom)
                .NotEmpty().WithMessage("Classroom is required.");
        }
    }
}
