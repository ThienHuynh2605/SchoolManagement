using FluentValidation;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.Supports.Validations.AccountValidators;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.TeacherValidators
{
    public class TeacherAccountValidator : AccountValidator<TeacherAccountDto>
    {
        public TeacherAccountValidator(SchoolDbContext context) : base(context) 
        {
        }
    }
}
