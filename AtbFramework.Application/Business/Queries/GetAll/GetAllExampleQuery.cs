using AtbFramework.Domain.Commons.Result;
using AtbFramework.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Application.Business.Queries.GetAll
{
    public class GetAllExampleQuery:IRequest<IResult>
    {
        public Expression<Func<ExampleClass, bool>> Predicate { get; set; } = null;
    }
}
