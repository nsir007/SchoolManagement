using EducationalSystem.Models;
using Library.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using VM;

namespace Services.Student
{
    public interface IClassServices
    {
        Result<List<Class>> GetAllClasses();
        Result<bool> Insertclass(ClassViewModel model);
        Result<bool> Updateclass(ClassViewModel model);
        Result<bool> Deleteclass(int? id);
        Result<ClassViewModel> GetclassById(int? id);

    }
}
