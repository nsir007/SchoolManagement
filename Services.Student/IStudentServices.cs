using EducationalSystem.Models;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using VM;

namespace Services.Student
{
   public interface IStudentServices
    {
           Result<bool> NewAdmission(StudentViewModal model);
        Result<bool> UpdateAdmission(StudentViewModal model);
        Result<List<student_info>> GetStudentByClass(StudentViewModal model);
        Result<StudentViewModal> getStudentById(int id);
        Result<bool> studentStatusChange(int id,string status);
    }
}
