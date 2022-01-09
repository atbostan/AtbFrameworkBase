using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Infrastructure.Interceptors
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
    public class MethodInterceptorBaseAttribute : Attribute, IInterceptor
    {
        /// <summary>
        /// This property use for giving a spesific order to operations
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// This method use for method interception with the help of Castle.Dynamicproxy
        /// </summary>
        /// <param name="invocation"></param>
        public virtual void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
