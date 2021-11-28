using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Application.CrossCuttingConcerns.Logging.LogEntities
{
    public class LogDetailWithException:LogDetails
    {
        public string ExceptionMessages { get; set; }
    }
}
