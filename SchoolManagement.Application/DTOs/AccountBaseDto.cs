using SchoolManagement.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs
{
    public class AccountBaseDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
