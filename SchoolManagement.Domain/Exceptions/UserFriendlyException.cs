using EnumsNET;
using SchoolManagement.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Exceptions
{
    public class UserFriendlyException : Exception
    {
        public UserFriendlyException(ErrorCode errorCode)
            : base(errorCode.AsString(EnumFormat.Description))
        {

        }

        public UserFriendlyException(string mess)
            : base(mess)
        {

        }
    }
}
