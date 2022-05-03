using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Domain.Commons.Constants.Messages;
using AtbFramework.Domain.Commons.Result;
using AtbFramework.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AtbFramework.Application.Business.Commands.Add
{
    public class DeleteExampleClassCommand: IRequest<IResult>
    {
        public int _id { get; set; }

        public bool _hardDelete { get; set; } = false;

        public class DeleteExampleClassCommandHandler : IRequestHandler<DeleteExampleClassCommand, IResult>
        {
            private readonly IRepository<ExampleClass, int> _repository;
            private readonly IMapper _mapper;

            public DeleteExampleClassCommandHandler(IMapper mapper, IRepository<ExampleClass, int> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<IResult> Handle(DeleteExampleClassCommand request, CancellationToken cancellationToken)
            {
                if (request._hardDelete)
                {
                    var entity = await _repository.Find(x => x.Id.Equals(request._id));
                    var result =  _repository.HardDelete(entity).IsCompletedSuccessfully;
                    return result == false ? new Result(false, ErrorMessages.DeleteMessage.Select(x => x.ToString()).ToList()) : new Result(true, SuccessMessages.DeleteMessage.Select(x=>x.ToString()).ToList());
                }
                else
                {
                    var entity = await _repository.Find(x => x.Id.Equals(request._id));
                    var result =  _repository.Delete(entity).IsCompletedSuccessfully;
                    return result == false ? new Result(false, ErrorMessages.DeleteMessage.Select(x => x.ToString()).ToList()) : new Result(true, SuccessMessages.DeleteMessage.Select(x => x.ToString()).ToList());
                }
             
            }
        }
    }
}
