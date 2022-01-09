using AtbFramework.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Infrastructure.Validation.FluentValidation
{
    public class ExampleValidator:AbstractValidator<ExampleClass>
    {
        
        public ExampleValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).Length(3, 35);
            RuleFor(c => c.Name).Must(NameFirstLetterControl);
        }

        private bool NameFirstLetterControl(string arg)
        {
            return arg.StartsWith('Ğ') ? false : true;
        }
    }
}
