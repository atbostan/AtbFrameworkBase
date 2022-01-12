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
        private readonly IBaseService<ExampleClass,int,ExampleDto> _baseExampleService;
        private readonly IMediator _mediator;
        public ExampleController(IBaseService<ExampleClass ,int, ExampleDto> baseExampleService , IMediator mediator)
        {
            _baseExampleService = baseExampleService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IResult> GetExample()
        {
            var query = new GetAllExampleQuery();
           return await _mediator.Send(query);
            
        }

        [HttpPost]
        public async Task<IResult> Add(AddExampleClassCommand ec)
        {
            return await _mediator.Send(ec);
        }
    }
}
