//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EducationalSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AttendanceDetail
    {
        [Key]
        public int DetailId { get; set; }
        public int AttendanceId { get; set; }
        public string Status { get; set; }
        public int StudentId { get; set; }
        public string Reason { get; set; }
    
        public virtual Attendance Attendance { get; set; }
    }
}
