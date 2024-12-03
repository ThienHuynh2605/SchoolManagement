﻿using SchoolManagement.Domain.Models.Enums;

namespace SchoolManagement.Application.DTOs.LoginDtos
{
    public class LoginDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
