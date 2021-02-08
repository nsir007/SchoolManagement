using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VM
{
   public class SubjectViewModel
    {
        
        public int? SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }
    }
}
