﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs
{
    public class CreateStudentDto : PeopleBaseDto
    {
        public StudentAccountDto? Account { get; set; }
    }
}
