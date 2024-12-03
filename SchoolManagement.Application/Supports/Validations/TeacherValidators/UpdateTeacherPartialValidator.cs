using FluentValidation;
using SchoolManagement.Application.DTOs.TeacherDtos;

namespace SchoolManagement.Application.Supports.Validations.TeacherValidators
{
    public class UpdateTeacherPartialValidator : PeopleBaseValidator<UpdateTeacherPartialDto>
    {
        public UpdateTeacherPartialValidator()
        {
            RuleFor(s => s.SubjectId)
               .NotEmpty().WithMessage("SubjectId is required.");
        }
    }
}
