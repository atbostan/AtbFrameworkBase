using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AtbFramework.Domain.Commons.Result;

namespace AtbFramework.Infrastructure.Validation
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, IValidator
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
                IResult res = new Result();
                res.Message = new List<string>();
                foreach (var VARIABLE in failures)
                {
                    res.Message.Add(VARIABLE.ErrorMessage);
                    res.Success = false;
                }
                return Task.FromResult((TResponse)res);
            }
            else
            {
                return next();

            }
        }
    }
}
