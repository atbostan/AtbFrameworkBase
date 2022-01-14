using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtbFramework.Application.DTOs;
using AtbFramework.Application.Interfaces.Business;
using AtbFramework.Domain.Commons.Result;
using AtbFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AtbFramework.Application.Business.Queries.GetAll;
using AtbFramework.Application.Business.Commands.Add;

namespace AtbFramework.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("examples")]
        public async Task<IResult> GetExamples()
        {
            var query = new GetAllExampleQuery();
           return await _mediator.Send(query);
            
        }

        [HttpGet("examples/{Id}")]
        public async Task<IResult> GetExample(int Id)
        {
            var query = new GetAllExampleQuery();
            query._filter.Id = Id;
            return await _mediator.Send(query);
        }

        [HttpDelete("examples/{Id}")]
        public async Task<IResult> Delete(int Id)
        {
            var cmd = new DeleteExampleClassCommand(){_id = Id};
            return await _mediator.Send(cmd);
        }

        [HttpDelete("examples/{Id}/remove")]
        public async Task<IResult> Remove(int Id)
        {
            var cmd = new DeleteExampleClassCommand() { _id = Id ,_hardDelete = true};
            return await _mediator.Send(cmd);
        }

        [HttpPut("examples")]
        public async Task<IResult> Update(UpdateExampleClassCommand ec)
        {
            return await _mediator.Send(ec);
        }

        [HttpPost("examples")]
        public async Task<IResult> Add(AddExampleClassCommand ec)
        {
            return await _mediator.Send(ec);
        }
    }
}
