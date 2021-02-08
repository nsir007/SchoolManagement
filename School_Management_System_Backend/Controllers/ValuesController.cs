using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationalSystem.Models;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Services.Student;
using VM;

namespace School_Management_System_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly IClassServices _ClassServices;

        //public ValuesController(IClassServices classServices)
        //{
        //    this._ClassServices = classServices;
        //}

        private IClassServices _ClassServices { get; set; }
        public ValuesController(IClassServices ClassServices)
        {
            this._ClassServices = ClassServices;
        }




        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Class>> Get()
        {
            var result = new Result<List<Class>>();

            result = _ClassServices.GetAllClasses();
            return result.Data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
