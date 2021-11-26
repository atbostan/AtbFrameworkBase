using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Domain.Commons.Result
{
    public interface IResult
    {
        public object Data { get; }
        public bool Success { get; }
        public string Message { get; }
    }
}
