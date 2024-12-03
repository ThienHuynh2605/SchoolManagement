using FluentValidation;
using SchoolManagement.Application.DTOs.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Supports.Validations.StudentValidations
{
    public class UpdateStudentValidator : PeopleBaseValidator<UpdateStudentDto>
    {
        public UpdateStudentValidator()
        {
            RuleFor(s => s.GradeId)
                .NotEmpty().WithMessage("GradeId is required.");
        }
    }
}
