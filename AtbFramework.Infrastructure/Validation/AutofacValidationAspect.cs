using AtbFramework.Infrastructure.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Infrastructure.Validation
{
    public class AutofacValidationAspect:MethodInterception
    {
        private Type _validatorType;
        public AutofacValidationAspect(Type validatorType)
        {
            // Check for proper validator
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("This type of validator not valid for using entity");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Generate instance with reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Get the type of entity to be validated
            var entites = invocation.Arguments.Where(t => t.GetType() == entityType); //Check the method's parameter same type with validator entity
            foreach (var entity in entites)
            {
                ValidationTool.Validate(validator,entity); //Validate argument(s)

            }
        }
    }
}
