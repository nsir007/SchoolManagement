using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationalSystem.Models;
using Library.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Student;
using VM;

namespace School_Management_System_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _IStudentServices;
        public StudentController(IStudentServices StudentServices)
        {
            this._IStudentServices = StudentServices;
        }
        [Route("NewAdmission")]
        [HttpPost]
        public Result<bool> NewAdmission(StudentViewModal model)
        {
            var result = new Result<bool>();
            if (model.Simg.IsNotNullOrEmpty())
            {
              string name=  Base64ToImage.BaseToImage(model.Simg);
                model.base64textString = name;
            }
            result = _IStudentServices.NewAdmission(model);

            return (result);
        }
        [Route("UpdateAdmission")]
        [HttpPost]
        public Result<bool> UpdateAdmission(StudentViewModal model)
        {
            var result = new Result<bool>();
            if (model.Simg.IsNotNullOrEmpty())
            {
                string name = Base64ToImage.BaseToImage(model.Simg);
                model.base64textString = name;
            }
            result = _IStudentServices.UpdateAdmission(model);

            return (result);
        }
        [Route("GetStudentByClass")]
        
        [HttpPost]
        public Result<List<student_info>> GetStudentByClass(StudentViewModal model)
        {
            var result = new Result<List<student_info>>();
            
            result = _IStudentServices.GetStudentByClass(model);

            return (result);
        }
        
       [Route("getStudentById")]
        [HttpGet]
        public StudentViewModal getStudentById(int id)
        {
            var result = new Result<StudentViewModal>();

            result = _IStudentServices.getStudentById(id);

            return (result.Data); 
        }
        [Route("studentStatusChange")]
        public bool studentStatusChange(int id,string status)
        {
            var result = new Result<bool>();

            result = _IStudentServices.studentStatusChange(id, status);

            return (result.Data);
        }
    }
}