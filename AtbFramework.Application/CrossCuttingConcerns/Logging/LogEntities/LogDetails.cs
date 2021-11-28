using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Application.CrossCuttingConcerns.Logging.LogEntities
{
    public class LogDetails 
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public string User { get; set; }
        public List<LogParameters> Parameters { get; set; }

    }
}
