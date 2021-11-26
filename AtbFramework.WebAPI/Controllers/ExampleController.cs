using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtbFramework.Application.Interfaces.Business;
using AtbFramework.Domain.Commons.Result;
using AtbFramework.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtbFramework.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IBaseService<ExampleClass,int> _baseExampleService;
        public ExampleController(IBaseService<ExampleClass ,int> baseExampleService)
        {
            _baseExampleService = baseExampleService;
        }

        [HttpGet]
        public async Task<IResult> GetExample()
        {
           return await _baseExampleService.GetAll();
            
        }

        [HttpPost]
        public async Task<IResult> Add(ExampleClass ec)
        {
            return await _baseExampleService.Add(ec);
        }
    }
}
