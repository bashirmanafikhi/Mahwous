﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mahwous.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationFailures = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null);

            if (validationFailures.Any())
            {
                throw new ValidationException(validationFailures);
            }

            return next();
        }
    }
}
