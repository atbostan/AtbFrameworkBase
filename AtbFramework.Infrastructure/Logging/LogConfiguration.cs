 using System;
using System.Collections.Generic;
 using System.Globalization;
 using System.Linq;
using System.Text;
using System.Threading.Tasks;
 using Serilog;

 namespace AtbFramework.Infrastructure.Logging
{
    public class LogConfiguration
    {
        public LogConfiguration()
        {

            var day = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Replace("/", "");
            var hour = DateTime.Now.Hour;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: $@"C:\logs\{day}\{hour}\logs.txt",
                    shared: true,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
