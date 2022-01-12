using AtbFramework.Application.DTOs;
using AtbFramework.Domain.Commons.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Application.Business.Commands.Add
{
    public class AddExampleClassCommand:IRequest<IResult>
    {

        public ExampleDto exampleDto { get; set; }
    }
}
