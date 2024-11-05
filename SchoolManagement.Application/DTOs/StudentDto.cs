﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs
{
    public class StudentDto
    {
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? HomeTown { get; set; }
    }
}
