﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Domain.Entities.Base;

namespace SchoolManagement.Domain.Entities
{
    public class StudentAccount : Account
    {
        public Student? Student { get; set; }
        public int? StudentId { get; set; }
    }
}
