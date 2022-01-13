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
           
  

            Log.Information(reqInfo.Name);

            TResponse response = await next();

            IResult checkIfError = (IResult)response;



            if (!checkIfError.Success)
            {
                var yyy=new LogMessageEntity(false, checkIfError.Message).ToString();
                Log.Error(new LogMessageEntity(false, checkIfError.Message).ToString());

            }
            else
            {
                Log.Information(new LogMessageEntity(true).ToString());
            }

            Log.CloseAndFlush();

            return response;
        }
    }
}
