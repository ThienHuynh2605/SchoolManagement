﻿using FluentValidation;
using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.Supports.Validations.AccountValidators;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Supports.Validations.PrincipalValidators
{
    public class PrincipalAccountValidator : AccountValidator<PrincipalAccountDto>
    {
        private readonly SchoolDbContext _context;
        public PrincipalAccountValidator(SchoolDbContext context) : base(context)
        {
            _context = context;
            RuleFor(s => s.UserName)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .Length(3, 50).WithMessage("Username must be between 3 and 50 characters long.")
                .Matches("^[a-zA-Z0-9.@]+$").WithMessage("Username can only contain letters, numbers, dots, and @.")
                .Must(BeUniqueUsername).WithMessage("Username already exists.");
        }

        private bool BeUniqueUsername(string username)
        {
            return !_context.PrincipalAccounts
                .Any(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}
