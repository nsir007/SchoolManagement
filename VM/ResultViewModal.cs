
using System;
using System.Collections.Generic;
using System.Text;

namespace VM
{
  public  class ResultViewModal
    {

        public int ID { get; set; }
        public Nullable<int> sid { get; set; }
        public double total { get; set; }
        public Nullable<double> obtain { get; set; }
        public Nullable<double> persentage { get; set; }
        public string grade { get; set; }
        public string classs { get; set; }
        public string subject { get; set; }
        public Nullable<System.DateTime> Datee { get; set; }
        public string Added_by { get; set; }
    }
}
