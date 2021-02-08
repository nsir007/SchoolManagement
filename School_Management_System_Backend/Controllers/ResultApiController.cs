using EducationalSystem.Models;
using Library.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VM;

namespace School_Management_System_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultApiController : ControllerBase
    {
        private readonly IStudentServices _IStudentServices;
        public ResultApiController(IStudentServices StudentServices)
        {
            this._IStudentServices = StudentServices;
        }
        [Route("ResultByClass")]
        [HttpGet]
        public Result<List<student_info>> ResultByClass(string classs)
        {
            var result = new Result<List<student_info>>();
            StudentViewModal modal = new StudentViewModal();
            modal.StatusVal = "active";
            modal.Classname = classs;
            result = _IStudentServices.GetStudentByClass(modal);
            return (result);
        }
    }
}
