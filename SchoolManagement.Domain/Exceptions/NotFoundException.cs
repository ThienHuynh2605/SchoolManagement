using EnumsNET;
using SchoolManagement.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(ErrorCode errorCode) : base(errorCode.AsString(EnumFormat.Description))
        {

        }
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
