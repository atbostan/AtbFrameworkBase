using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtbFramework.Infrastructure.Validation
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new FluentValidation.ValidationContext<TRequest>(request);
            var failures = _validator.Select(x => x.Validate(context))
                .SelectMany(x => x.Errors).Where(x => x != null).ToList();

            if (failures.Any())
            {
                throw new FluentValidation.ValidationException(failures);
            }
            return next();
        }
    }
}
