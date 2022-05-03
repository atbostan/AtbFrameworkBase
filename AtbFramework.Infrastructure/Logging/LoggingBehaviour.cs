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
using AtbFramework.Domain.Commons.Result;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AtbFramework.Infrastructure.Logging
{
    public class LoggingBehaviour<TRequest, TResponse> : LogConfiguration, IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
   
        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var reqInfo = typeof(TRequest);
            string classPath = reqInfo.FullName;
            List<string> logMessages = new List<string>();
            logMessages.Add(classPath);

            TResponse response = await next();
            IResult checkIfError = (IResult)response;

            if (reqInfo.Name.ToLower().Contains("query"))
            {
                if (!checkIfError.Success)
                {
                    logMessages.AddRange(checkIfError.Message);
                    string message = new LogMessageEntity(logMessages, false).ToString();
                    Log.Error(message);

                }
                else
                {
                    string responseJson = JsonConvert.SerializeObject(checkIfError.Data).ToString();
                    logMessages.Add(responseJson);
                    logMessages.AddRange(checkIfError.Message);
                    string message = new LogMessageEntity(logMessages,true).ToString();
                    Log.Information(message);
                }

            }
            else
            {
                string requestJson = JsonConvert.SerializeObject(request).ToString();
                logMessages.Add(requestJson);

                if (!checkIfError.Success)
                {
                    logMessages.AddRange(checkIfError.Message);
                    Log.Error(new LogMessageEntity(logMessages, false).ToString());

                }
                else
                {
                    logMessages.AddRange(checkIfError.Message);
                    Log.Information(new LogMessageEntity(logMessages, true).ToString());
                }
            }

            Log.CloseAndFlush();

            return response;
        }
    }
}
