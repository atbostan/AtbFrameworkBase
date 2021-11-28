using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace AtbFramework.Application.Utilities.Interceptors
{
    public class ApectInterceptorSelector: IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptorBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptorBaseAttribute>(true).ToList();
            classAttributes.AddRange(methodAttributes);
            return classAttributes.OrderBy(x => x.Priority).ToArray();
            // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));  //*** Bu şekilde tüm metotlarda söz konusu işlemi yaptırırım. Örneğin burada tüm metotlar loglanır
            //classAttributes.Add(new PerformanceAspect(5)); //Tüm metotlara performans testi uygularız. Eğer 5 saniyeyi geçerse uyar


        }
    }
}
