using AtbFramework.Application.Business.Commands.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Infrastructure.Validation
{
    public class AddExampleClassCommandValidator:AbstractValidator<AddExampleClassCommand>
    {
        public AddExampleClassCommandValidator()
        {
            RuleFor(x => x._exampleDto.Name).NotEmpty();
            RuleFor(x => x._exampleDto.Number).NotEmpty();
        }
    }
}
