using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AtbFramework.Application.DTOs;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Domain.Commons.Constants.Messages;
using AtbFramework.Domain.Commons.Result;
using AtbFramework.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtbFramework.Application.Business.Commands.Add
{
    public class UpdateExampleClassCommand : IRequest<IResult>
    {
        public ExampleDto _exampleDto { get; set; }


        public class UpdateExampleClassCommandHandler : IRequestHandler<UpdateExampleClassCommand, IResult>
        {
            private readonly IRepository<ExampleClass, int> _repository;
            private readonly IMapper _mapper;

            public UpdateExampleClassCommandHandler(IRepository<ExampleClass, int> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateExampleClassCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<ExampleClass>(request._exampleDto);
                var recordedEntity = _repository.Find(x => x.MockId == request._exampleDto.MockId).Result;
                var updatedEntity = _mapper.Map(recordedEntity, entity);
                var y = entity;
                var result = await _repository.Update(updatedEntity);
                return result == null ? new Result(false, ErrorMessages.UpdateMessage.Split(',').ToList()) : new Result(true, SuccessMessages.UpdateMessage.Split(',').ToList());
            }
        }
    }
}
