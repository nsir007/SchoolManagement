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
  public  class StudentServices:IStudentServices
    {
        private readonly StudentContext _context;
        static HttpClient client = new HttpClient();
        public StudentServices(StudentContext cSRWorker)
        {
            this._context = cSRWorker;
        }

        public Result<bool> NewAdmission(StudentViewModal modal)
        {

            var result = new Result<bool>();
            try
            {
                var dateAndTime = DateTime.Now;
                var date = dateAndTime.Date;
                var dateValue2 = Convert.ToDateTime(modal.Date_of_birth);
                var dateValue3= dateValue2.ToString("yyyy/MM/dd");
                if (modal.Name.IsNotNullOrEmpty())
                {
                    student_info Std = new student_info();
                    Std.Name = modal.Name;
                    Std.FatherName = modal.FatherName;
                    Std.Gender = modal.Gender;
                    Std.Date_of_birth =Convert.ToDateTime(dateValue3);
                    Std.S_cnic = modal.S_cnic;
                    Std.Religion = modal.Religion;
                    Std.Cast = modal.Cast;
                    Std.Family_id = modal.Family_id;
                    Std.F_cnic = modal.F_cnic;
                    Std.Phone = modal.Phone;
                    Std.Father_ocupation = modal.Father_ocupation;
                    Std.Address = modal.Address;
                    Std.Simg = modal.base64textString;
                    Std.Class = modal.Classname;
                    Std.ClassRoll = modal.ClassRoll;
                    Std.Monthly_dues = modal.Monthly_dues;
                    Std.Admn_fee = modal.Admn_fee;
                    Std.Refrence = modal.Refrence;
                    Std.status = true;
                    Std.Date_of_admn = date;
                    Std.Admited_by = "Nsrullah";
                    _context.student_info.Add(Std);
                    _context.SaveChanges();
                    result.Message = "New Admission Succcessfully";
                    result.Data = true;
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "Record already have same name";
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
        public Result<bool> UpdateAdmission(StudentViewModal modal)
        {

            var result = new Result<bool>();
            try
            {
                var dateValue2 = Convert.ToDateTime(modal.Date_of_birth);
                var dateValue3 = dateValue2.ToString("yyyy/MM/dd");
                var Std = (from s in _context.student_info where s.S_id == modal.S_id select s).FirstOrDefault();
                if (Std.IsNotNullOrEmpty())
                {
                    
                    Std.Name = modal.Name;
                    Std.FatherName = modal.FatherName;
                    if (modal.Gender.IsNotNullOrEmpty())
                        Std.Gender = modal.Gender;
                    if(modal.Date_of_birth.IsNotNullOrEmpty())
                    Std.Date_of_birth = Convert.ToDateTime(dateValue3);
                    Std.S_cnic = modal.S_cnic;
                    Std.Religion = modal.Religion;
                    Std.Cast = modal.Cast;
                    Std.Family_id = modal.Family_id;
                    Std.F_cnic = modal.F_cnic;
                    Std.Phone = modal.Phone;
                    Std.Father_ocupation = modal.Father_ocupation;
                    Std.Address = modal.Address;
                    Std.Simg = modal.base64textString;
                    if (modal.Classname.IsNotNullOrEmpty())
                        Std.Class = modal.Classname;
                    Std.ClassRoll = modal.ClassRoll;
                    Std.Monthly_dues = modal.Monthly_dues;
                    Std.Admn_fee = modal.Admn_fee;
                    Std.Refrence = modal.Refrence;
                    Std.Admited_by = "Nsrullah";
                    _context.SaveChanges();
                    result.Message = "New Admission Succcessfully";
                    result.Data = true;
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "Record already have same name";
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
        public Result<List<student_info>> GetStudentByClass(StudentViewModal modal)
        {
           
            bool bit = true;
            if (modal.StatusVal == "active")
                bit = true;
            else if (modal.StatusVal == "left")
                bit = false;
            var result = new Result<List<student_info>>();
            string where = string.Empty;
            if (modal.Classname.IsNotNullOrEmpty())
            {
                where = " s.Class='"+modal.Classname+"'";
            }
            if (modal.StatusVal.IsNotNullOrEmpty()&&(bit==true||bit==false))
            {
                where += " and s.Status=" + bit;
            }
            try
            {
                List<student_info> _Info = new List<student_info>();
                if (modal.StatusVal== "all")
                { _Info = (from s in _context.student_info where s.Class == modal.Class select s).ToList();}
                else
                { _Info = (from s in _context.student_info where s.Class == modal.Class && s.status == bit select s).ToList(); }
                //string query = @"select * from student_info s
                //                    where "+where;
                //var AllStudent = _context.ExecuteQuery<StudentViewModal>(query).ToList();


                if (_Info.IsNotNullOrEmpty() && _Info.Count() > 0)
                {
                    result.Data = _Info;
                    result.Message = "successfully";
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "record not found";
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

        public Result<StudentViewModal> getStudentById(int id)
        {
            
            var result = new Result<StudentViewModal>();
            
            try
            {
                string query = @"select * from student_info  where S_id=" + id;
                var StudentRec = _context.ExecuteQuery<StudentViewModal>(query).FirstOrDefault();


                if (StudentRec.IsNotNullOrEmpty())
                {
                    

                    result.Data = StudentRec;
                    result.Message = "successfully";
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "record not found";
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


        public Result<bool> studentStatusChange(int id,string status)
        {
            bool bit = true;
            var result = new Result<bool>();
            if (status== "false")
                bit = false;
            try
            {
                var StudentRec = (from s in _context.student_info where s.S_id == id select s).FirstOrDefault();

                if (StudentRec.IsNotNullOrEmpty())
                {
                    StudentRec.status = bit;
                    _context.SaveChanges();
                    result.Data = true;
                    result.Message = "successfully";
                    result.ResultType = ResultType.Success;
                }
                else
                {
                    result.Message = "record not found";
                    result.Data = false;
                    result.ResultType = ResultType.Empty;
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

    }
}
