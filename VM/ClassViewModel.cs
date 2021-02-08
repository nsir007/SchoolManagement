
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VM
{
    public class ClassViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }
        public int? StudentRecordId { get; set; }
        public string StudentName { get; set; }
        public Nullable<long> StudentRollNo { get; set; }
       
    }
}
