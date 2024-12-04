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

        #region Student = ErrorCode + 1000
        StudentError = ErrorCode + 1000,
        [Display(GroupName = "Student")]
        [Description("Student not found.")]
        NotFoundStudent = StudentError + 1,
        #endregion

        #region Teacher = ErrorCode + 2000
        TeacherError = ErrorCode + 2000,
        [Display(GroupName = "Teacher")]
        [Description("Teacher not found.")]
        NotFoundTeacher = TeacherError + 1,
        #endregion

        #region Principal = ErrorCode + 3000
        PrincipalError = ErrorCode + 3000,
        [Display(GroupName = "Principal")]
        [Description("Principal not found.")]
        NotFoundPrincipal = PrincipalError + 1,
        #endregion

        #region Grade = ErrorCode + 4000
        GradeError = ErrorCode + 4000,
        [Display(GroupName = "Grade")]
        [Description("Grade not found.")]
        NotFoundGrade = GradeError + 1,
        #endregion

        #region Subject = ErrorCode + 5000
        SubjectError = ErrorCode + 5000,
        [Display(GroupName = "Subject")]
        [Description("Subject not found.")]
        NotFoundSubject = SubjectError + 1,
        #endregion
    }
}
