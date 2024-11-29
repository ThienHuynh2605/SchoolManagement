using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.AccountValidators
{
    public class AccountValidator<T> : AbstractValidator<T> where T : AccountBaseDto
    {
        private readonly SchoolDbContext _context;
        public AccountValidator(SchoolDbContext context)
        {
            RuleFor(s => s.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .Length(6, 100).WithMessage("Password must be between 6 and 100 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
        }
    }
}
