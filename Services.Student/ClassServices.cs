using Data.Student;
using Library.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using VM;
using Services.Student;
using System.Data;
using System.Reflection;
using EducationalSystem.Models;

namespace Services.Student
{
    public class ClassServices : IClassServices
    {
       
        private readonly StudentContext _context;
        static HttpClient client = new HttpClient();
        public ClassServices(StudentContext cSRWorker)
        {
            this._context = cSRWorker;
        }
        /// <summary>
        /// Author : Nasrullah
        /// Created Date : 24/11/2020
        /// </summary>   
        /// <returns>Get All Claases</returns>
        public Result<List<Class>> GetAllClasses()
        {
            var result = new Result<List<Class>>();
            try
            {
                
                var AllClasses = _context.Classes
                                  .FromSql("select * from [Classes] where Status=1")
                                  .ToList();
                if (AllClasses.IsNotNullOrEmpty() && AllClasses.Count() > 0)
                {
                    result.Data = AllClasses;
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Data = null;
                    result.ResultType = ResultType.Empty;
                }
            }
            catch (Exception e)
            {
                result.Data = null;
                result.ResultType = ResultType.Exception;
                result.Exception = e;
                result.Message = e.Message;
            }
            return result;
        }
        public Result<bool> Insertclass(ClassViewModel model)
        {
            var result = new Result<bool>();
            try
            {
                var Classsobj = (from s in _context.Classes where s.Name == model.Name select s).ToList();
                if (Classsobj.Count==0)
                {
                    Class clas = new Class();
                    clas.Name = model.Name;
                    clas.Status = true;
                    _context.Classes.Add(clas);
                    _context.SaveChanges();
                    result.Data = true;
                    result.Message = "Record saved Succcessfully";
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "Class name already exist";
                    result.Data = false;
                    result.ResultType = ResultType.Duplicate;
                }

            }
            catch (Exception e)
            {

                result.Data = false;
                result.ResultType = ResultType.Exception;
                result.Exception = e;
                result.Message = "Error";
            }
            return result;
        }
        public Result<bool> Deleteclass(int? id)
        {
            var result = new Result<bool>();
            if (id.IsNotNullOrEmpty())
            {
                try
                {
                    var obj = (from s in _context.Classes where s.Id == id select s).FirstOrDefault();
                    if (obj.IsNotNullOrEmpty())
                    {
                        obj.Status = false;
                        _context.SaveChanges();
                        result.Message = "record deleted successfully";
                        result.Data = true;
                        result.ResultType = ResultType.Success;
                    }
                    else
                    {
                        result.Data = false;
                        result.Message = "record not found";
                        result.ResultType = ResultType.Empty;
                    }
                   
                }
                catch (Exception e)
                {

                    result.Data = false;
                    result.Message = "record not delete";
                    result.ResultType = ResultType.Exception;
                    result.Exception = e;
                    result.Message = e.Message;
                }
            }
            return result;
        }
        public Result<ClassViewModel> GetclassById(int? id)
        {
            var result = new Result<ClassViewModel>();
            ClassViewModel model = new ClassViewModel();
            if (id.IsNotNullOrEmpty())
            {
                try
                {
                    var obj = (from s in _context.Classes where s.Id == id select s).FirstOrDefault();
                    if (obj.IsNotNullOrEmpty())
                    {
                        model.Id = obj.Id;
                        model.Name = obj.Name;
                        result.Data = model;
                        result.ResultType = ResultType.Success;
                    }
                    else
                    {
                        result.Data = null;
                        result.Message = "record not found";
                        result.ResultType = ResultType.Empty;
                    }
                   
                }
                catch (Exception e)
                {

                    result.Data = null;
                    result.Message = "record not delete";
                    result.ResultType = ResultType.Exception;
                    result.Exception = e;
                    result.Message = e.Message;
                }
            }
            
            
            return result;
        }

      public  Result<bool> Updateclass(ClassViewModel model)
        {
            var result = new Result<bool>();
            try
            {
               


                var Classsobj = (from s in _context.Classes where s.Name == model.Name select s).ToList();
                if (Classsobj.Count == 0)
                {
                    var obj = (from s in _context.Classes where s.Id == model.Id select s).FirstOrDefault();
                    obj.Name = model.Name;
                    _context.SaveChanges();
                    result.Message = "Record updated Succcessfully";
                    result.Data = true;
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "Class name already exist";
                    result.Data = false;
                    result.ResultType = ResultType.Duplicate;
                }
                
            }
            catch (Exception e)
            {

                result.Data = false;
                result.ResultType = ResultType.Exception;
                result.Exception = e;
                result.Message = "Record not update";
            }
            return result;
        }
     
    }
}
