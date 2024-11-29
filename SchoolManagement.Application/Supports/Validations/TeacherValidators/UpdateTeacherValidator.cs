using FluentValidation;
using SchoolManagement.Application.DTOs.TeacherDtos;

namespace SchoolManagement.Application.Supports.Validations.TeacherValidators
{
    public class UpdateTeacherValidator : PeopleBaseValidator<UpdateTeacherDto>
    {
        public UpdateTeacherValidator()
        {
            RuleFor(s => s.SubjectId)
               .NotEmpty().WithMessage("SubjectId is required.");
        }
    }
}
