using EducationalSystem.Models;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using VM;

namespace Services.Student
{
    public interface ISubjectServices
    {
        Result<List<Subject>> GetAllSubject();
        Result<bool> InsertSubject(SubjectViewModel model);
        Result<bool> UpdateSubject(SubjectViewModel model);
        Result<bool> DeleteSubject(int? id);
        Result<SubjectViewModel> GetSubjectById(int? id);

    }
}
