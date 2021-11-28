using AtbFramework.Application.CrossCuttingConcerns.Logging.Configuration;
using AtbFramework.Application.DependencyResolvers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;
namespace AtbFramework.Application.CrossCuttingConcerns.Logging.Service
{
    public class FileLogger:LoggerServiceBase
    {
        public FileLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var logConfig = configuration.GetSection("SeriLogConfigurations:FileLogConfiguration");
            var logFolderPath = new FileLogConfiguration() { Path = logConfig.ToString() };
            var logFilePath = string.Format("{0}{1}", Directory.GetCurrentDirectory() + logFolderPath, ".txt");

            Logger = new LoggerConfiguration()
               .WriteTo.File(
                   logFilePath,
                   rollingInterval: RollingInterval.Day,
                   retainedFileCountLimit: null,
                   fileSizeLimitBytes: 5000000,
                   outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
               .CreateLogger();
        }
    }
}
