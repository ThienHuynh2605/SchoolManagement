using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Models.Enums
{
    public enum ErrorCode
    {
        ErrorCode = 400,

        #region NotFoundStudent = ErrorCode + 1000
        StudentError = ErrorCode + 1000,

        [Display(GroupName = "StudentError")]
        [Description("Student not found..")]
        NotFoundStudent = StudentError + 1,

        #endregion
    }
}
