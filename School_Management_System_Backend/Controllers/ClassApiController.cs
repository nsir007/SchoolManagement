using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationalSystem.Models;
using Library.Core.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Student;
using VM;

namespace School_Management_System_Backend.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ClassApiController : ControllerBase
    {
        private readonly IClassServices _ClassServices;
        public ClassApiController(IClassServices classServices)
        {
            this._ClassServices = classServices;
        }
        
        [Route("Addclass")]
        [HttpPost]
        public Result<bool> Addclass(ClassViewModel model)
        {
          /// var testwebconfig = (long)HttpContext.Session.GetInt32("AgencyId");
            var result = new Result<bool>();

           result = _ClassServices.Insertclass(model);
            return (result);
        }
        [Route("Getclasses")]
        [HttpGet]
        public ActionResult<IEnumerable<Class>> Getclasses()
        {
            var result = new Result<List<Class>>();

            result = _ClassServices.GetAllClasses();
            return result.Data;
        }
        [Route("Deleteclasse")]
        public IActionResult Deleteclasse(int? id)
        {
            var result = new Result<bool>();

            result = _ClassServices.Deleteclass(id);
            if (result.Data.IsNotNullOrEmpty())
            {
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }

        }

        [Route("GetclassById")]
        [HttpGet]
        public IActionResult GetclassById(int? id)
        {
            var result = new Result<ClassViewModel>();

            result = _ClassServices.GetclassById(id);
            if (result.Data.IsNotNullOrEmpty())
            {
                return Ok(result.Data);
            }
            else
            {
                return Ok(result);
            }
        }
        [Route("updateclass")]
        [HttpPost]
        public Result<bool> updateclass(ClassViewModel model)
        {
            var result = new Result<bool>();

            result = _ClassServices.Updateclass(model);
           
                return (result);
            
        }
    }
}