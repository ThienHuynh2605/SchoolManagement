using FluentValidation;
using SchoolManagement.Application.DTOs.StudentDtos;

namespace SchoolManagement.Application.Supports.Validations.StudentValidations
{
    public class UpdateStudentPartialValidator : AbstractValidator<UpdateStudentPartialDto>
    {
        public UpdateStudentPartialValidator()
        {
            RuleFor(s => s.Name)
                .Length(1, 50).WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(s => s.DateOfBirth)
                .LessThan(DateTime.Today).WithMessage("Date of Birth must be before today.");

            RuleFor(s => s.Email)
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(s => s.GradeId)
                .NotEmpty().WithMessage("GradeId is required.");
        }
    }
}
