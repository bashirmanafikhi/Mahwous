using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Behaviors
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

        public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestType = typeof(TRequest).Name;

            try
            {
                return await next();
            }
            //catch (NotFoundException ex)
            //{
            //    _logger.LogError(ex, requestType + ' ' + ex.Message);
            //}
            catch (Exception ex)
            {
                throw ex;
                //_logger.LogCritical("not catched error: " +ex.Message);
            }

            return default(TResponse);
        }

    }
}
