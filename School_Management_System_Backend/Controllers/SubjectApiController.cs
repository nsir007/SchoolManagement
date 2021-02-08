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
    public class SubjectApiController : ControllerBase
    {
        private readonly ISubjectServices _SubjectServices;
        public SubjectApiController(ISubjectServices SubjectServices)
        {
            this._SubjectServices = SubjectServices;
        }

        [Route("AddSubject")]
        [HttpPost]
        public Result<bool> AddSubject(SubjectViewModel model)
        {
            /// var testwebconfig = (long)HttpContext.Session.GetInt32("AgencyId");
            var result = new Result<bool>();

            result = _SubjectServices.InsertSubject(model);
            return (result);
        }
        [Route("GetSubjects")]
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> GetSubjects()
        {
            var result = new Result<List<Subject>>();

            result = _SubjectServices.GetAllSubject();
            return result.Data;
        }
        [Route("Deletesubject")]
        public IActionResult Deletesubject(int? id)
        {
            var result = new Result<bool>();

            result = _SubjectServices.DeleteSubject(id);
            if (result.Data.IsNotNullOrEmpty())
            {
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }

        }

        [Route("GetsubjectById")]
        [HttpGet]
        public IActionResult GetsubjectById(int? id)
        {
            var result = new Result<SubjectViewModel>();

            result = _SubjectServices.GetSubjectById(id);
            if (result.Data.IsNotNullOrEmpty())
            {
                return Ok(result.Data);
            }
            else
            {
                return Ok(result);
            }
        }
        [Route("updatsubject")]
        [HttpPost]
        public Result<bool> updatsubject(SubjectViewModel model)
        {
            var result = new Result<bool>();

            result = _SubjectServices.UpdateSubject(model);

            return (result);

        }

    }
}