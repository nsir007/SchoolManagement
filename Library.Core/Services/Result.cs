using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class Result<T>
    {
        public ResultType ResultType { get; set; }

        public string Message { get; set; }
        public int RecordCount { get; set; }

        public DateTime RecordDateTime { get; set; }
        public T Data { get; set; }

        public List<ValidationResult> ValidationErrors { get; set; }

        public Exception Exception;
        

        public Result<TData> Duplicate<TData>()
        {
            var response = new Result<TData>
            {
                Message = this.Message,
                ResultType = this.ResultType,
                ValidationErrors = this.ValidationErrors                
            };

            return response;
        }
    }
}
