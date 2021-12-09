using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.CrossCuttingConcerns.Logging.Aspects;
using AtbFramework.Application.CrossCuttingConcerns.Logging.Service;
using Castle.DynamicProxy;

namespace AtbFramework.Application.Utilities.Interceptors
{
    public class ApectInterceptorSelector: IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptorBaseAttribute>(true).ToList();
            var methodAttributes =
                type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptorBaseAttribute>(true);
            if (methodAttributes != null)
            {
                classAttributes.AddRange(methodAttributes);
            }

            classAttributes.Add(new LogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();

        }
    }
}
