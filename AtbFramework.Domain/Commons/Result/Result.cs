using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Domain.Commons.Result
{
    public class Result:IResult
    {
        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success, object data) : this(success)
        {
            Data = data;
        }

        public Result( bool success, string message , object data) : this(success, message)
        {
            Data = data;
        }

        public object Data { get; }
        public bool Success { get; }
        public string Message { get; }
    }
}
