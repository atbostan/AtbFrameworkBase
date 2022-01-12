﻿using AtbFramework.Application.Interfaces.Repository;
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

namespace AtbFramework.Application.Business.Commands.Add
{
    public class AddExampleClassCommandHandler : IRequestHandler<AddExampleClassCommand, IResult>
    {
        private readonly IRepository<ExampleClass, int> _repository;
        private readonly IMapper _mapper;
        public AddExampleClassCommandHandler(IRepository<ExampleClass, int> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IResult> Handle(AddExampleClassCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ExampleClass>(request.exampleDto);
            var result = await _repository.Add(entity);
            return result == null ? new Result(false, ErrorMessages.CreateMessage) : new Result(true, SuccessMessages.CreateMessage, result.Id);
        }
    }
}