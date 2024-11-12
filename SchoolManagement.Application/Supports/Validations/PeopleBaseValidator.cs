using FluentValidation;
using SchoolManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Supports.Validations
{
    public class PeopleBaseValidator<T> : AbstractValidator<T> where T : PeopleBaseDto
    {
        public PeopleBaseValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .Length(1, 100)
                .WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(s => s.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(s => s.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .LessThan(DateTime.Today).WithMessage("Date of Birth must be before today.");

            RuleFor(s => s.HomeTown)
                .NotEmpty().WithMessage("HomeTown is required.");
        }
    }
}
