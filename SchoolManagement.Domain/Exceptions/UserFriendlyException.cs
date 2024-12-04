using EnumsNET;
using SchoolManagement.Domain.Models.Enums;

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
