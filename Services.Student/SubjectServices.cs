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
using EducationalSystem.Models;

namespace Services.Student
{
    public class SubjectServices : ISubjectServices
    {
       
        private readonly StudentContext _context;
        static HttpClient client = new HttpClient();
        public SubjectServices(StudentContext cSRWorker)
        {
            this._context = cSRWorker;
        }
        public Result<List<Subject>> GetAllSubject()
        {
            var result = new Result<List<Subject>>();
            try
            {
                var AllSubjects = _context.Subjects
                                  .FromSql("select * from Subjects where Status=1")
                                  .ToList();
                if (AllSubjects.IsNotNullOrEmpty() && AllSubjects.Count() > 0)
                {
                    result.Data = AllSubjects;
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

        public Result<bool> InsertSubject(SubjectViewModel model)
        {
            var result = new Result<bool>();
            try
            {
                var SubjectCheck = (from s in _context.Subjects where s.Name == model.SubjectName select s).ToList();

                if (SubjectCheck.Count == 0)
                {
                    Subject Sub = new Subject();
                    Sub.Name = model.SubjectName;
                    Sub.Status = true;
                    _context.Subjects.Add(Sub);
                    _context.SaveChanges();
                    result.Message = "Subject Added Succcessfully";
                    result.Data = true;
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "Subject name already exist";
                    result.Data = false;
                    result.ResultType = ResultType.Duplicate;
                }
                
            }
            catch (Exception e)
            {

                result.Data = false;
                result.ResultType = ResultType.Exception;
                result.Exception = e;
                result.Message = e.Message;
            }
            return result;
        }
        public Result<bool> DeleteSubject(int? id)
        {
            var result = new Result<bool>();
            if (id.IsNotNullOrEmpty())
            {
                try
                {
                    var obj = (from s in _context.Subjects where s.Id == id select s).FirstOrDefault();
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
        public Result<SubjectViewModel> GetSubjectById(int? id)
        {
            var result = new Result<SubjectViewModel>();
            SubjectViewModel model = new SubjectViewModel();
            if (id.IsNotNullOrEmpty())
            {
                try
                {
                    var obj = (from s in _context.Subjects where s.Id == id select s).FirstOrDefault();
                    if (obj.IsNotNullOrEmpty())
                    {
                        model.SubjectId = obj.Id;
                        model.SubjectName = obj.Name;
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

      public  Result<bool> UpdateSubject(SubjectViewModel model)
        {
            var result = new Result<bool>();
            try
            {
                var SubjectCheck = (from s in _context.Subjects where s.Name == model.SubjectName select s).ToList();
                if (SubjectCheck.Count == 0)
                {
                    var obj = (from s in _context.Subjects where s.Id == model.SubjectId select s).FirstOrDefault();
                    obj.Name = model.SubjectName;
                    _context.SaveChanges();
                    result.Message = "Record updated Succcessfully";
                    result.Data = true;
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "Subject name already exist";
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
