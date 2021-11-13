using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Exceptions
{
    public class RequestGenericExceptionHandler<TRequest, TResponse, TException> : IRequestExceptionHandler<TRequest, TResponse, TException>
        where TException : Exception
    {

        private readonly ILogger<TRequest> _logger;

        public RequestGenericExceptionHandler(ILogger<TRequest> logger)
        {
            _logger = logger;
        }


        public async Task Handle(TRequest request,
            TException exception,
            RequestExceptionHandlerState<TResponse> state,
            CancellationToken cancellationToken)
        {
            if (exception is NotFoundException)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning(requestName + ' ' + exception.Message);
            }

        }
    }
}
