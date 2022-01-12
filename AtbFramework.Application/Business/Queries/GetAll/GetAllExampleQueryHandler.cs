using AtbFramework.Application.DTOs;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Domain.Commons.Constants.Messages;
using AtbFramework.Domain.Commons.Result;
using AtbFramework.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtbFramework.Application.Business.Queries.GetAll
{
    public class GetAllExampleQueryHandler : IRequestHandler<GetAllExampleQuery, IResult>
    {
        private readonly IRepository<ExampleClass, int> _repository;
        private readonly IMapper _mapper;

        public GetAllExampleQueryHandler(IRepository<ExampleClass, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(GetAllExampleQuery request, CancellationToken cancellationToken)
        {
            var result = request.Predicate == null ? await _repository.GetAll() : await _repository.GetAll(request.Predicate);
            return result == null ? new Result(true, ErrorMessages.GetMessage) : new Result(true, _mapper.Map<List<ExampleDto>>(result));
        }
    }
}
