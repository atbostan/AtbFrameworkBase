using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Domain.Commons.Result
{
    public interface IResult
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public List<string> Message { get; set; }
    }
}
