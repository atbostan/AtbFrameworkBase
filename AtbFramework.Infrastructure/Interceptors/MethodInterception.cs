using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Infrastructure.Interceptors
{
    public abstract class MethodInterception:MethodInterceptorBaseAttribute
    {
        /// <summary>
        /// Intercept before method invocation
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation) { }

        /// <summary>
        /// Intercepter after method completed
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnAfter(IInvocation invocation) { }

        /// <summary>
        /// Intercept if the exception will occur
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnException(IInvocation invocation) { }

        /// <summary>
        /// Intercept if the method completed successfully
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation) { }

        /// <summary>
        /// This method help to interpretation about when intercept an operation
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {

                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);

                }

            }
            OnAfter(invocation);

            
        }
    }
}
