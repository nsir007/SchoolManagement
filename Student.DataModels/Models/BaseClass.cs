using System;
using System.Collections.Generic;
using System.Text;

namespace Student.DataModels.Models
{
   public class BaseClass
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdateBy { get; set; }
    }
}
