using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestType = typeof(TRequest).Name;
            var response = await next();

            if (requestType.EndsWith("Command"))
            {
                //_logger.LogInformation($"Command Request: {request}");
            }
            else if (requestType.EndsWith("Query"))
            {
                //_logger.LogInformation($"Query Request: {request}");
                //_logger.LogInformation($"Query Response: {response}");
            }
            else
            {
                //throw new Exception("The request is not the Command or Query type");
            }

            return response;
        }

    }
}
