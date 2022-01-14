using AtbFramework.Domain.Commons.Result;
using AtbFramework.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AtbFramework.Application.Business.Queries.QueryFilterEntities;
using AtbFramework.Application.DTOs;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Domain.Commons.Constants.Messages;
using AutoMapper;

namespace AtbFramework.Application.Business.Queries.GetAll
{
    public class GetAllExampleQuery:IRequest<IResult>
    {
        public ExampleEntityFilter _filter { get; set; } = null;

        public GetAllExampleQuery()
        {
            _filter = new ExampleEntityFilter();
        }

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
                
                    if (request._filter.Id >0)
                    {
                        var result = request._filter == null ? await _repository.GetAll() : await _repository.GetAll(x=>x.Id==request._filter.Id);
                        return result == null ? new Result(true, ErrorMessages.GetMessage) :
                            result.Count == 1 ? new Result(true, message: SuccessMessages.ReadMessage.Split(',').ToList(), _mapper.Map<ExampleDto>(result.SingleOrDefault())) :
                            new Result(true, message: SuccessMessages.ReadMessage.Split(',').ToList(), _mapper.Map<List<ExampleDto>>(result));
                    }else if(request._filter.City!=null)
                    {
                        var result = request._filter == null ? await _repository.GetAll() : await _repository.GetAll(x => x.City == request._filter.City);
                        return result == null ? new Result(true, ErrorMessages.GetMessage) :
                            result.Count == 1 ? new Result(true, message: SuccessMessages.ReadMessage.Split(',').ToList(), _mapper.Map<ExampleDto>(result.SingleOrDefault())) :
                            new Result(true, message: SuccessMessages.ReadMessage.Split(',').ToList(), _mapper.Map<List<ExampleDto>>(result));
                    }
                    else
                    {
                        var result = await _repository.GetAll();
                        return result == null ? new Result(true, ErrorMessages.GetMessage) :
                            result.Count == 1 ? new Result(true, message: SuccessMessages.ReadMessage.Split(',').ToList(), _mapper.Map<ExampleDto>(result.SingleOrDefault())) :
                            new Result(true, message: SuccessMessages.ReadMessage.Split(',').ToList(), _mapper.Map<List<ExampleDto>>(result));
                    }
            
           
            }
        }
    }
}
