using MediatR;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AtbFramework.Infrastructure.Logging
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
        private IConfigurationRoot _config { get; set; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            var reqInfo = typeof(TRequest);
           
            var day = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture).Replace("/","");
            var hour = DateTime.Now.Hour;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: $@"C:\logs\${day}\${hour}\logs.txt", 
                    shared: true,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information(reqInfo.Name);


        
            var response =  next().IsFaulted;

            Log.Warning(reqInfo.Name);
            //Response
            return await next();
        }
    }
}
