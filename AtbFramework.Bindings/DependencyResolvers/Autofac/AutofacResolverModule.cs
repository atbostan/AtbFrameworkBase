using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;

namespace AtbFramework.Bindings.DependencyResolvers.Autofac
{
    public class AutofacResolverModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region AutofacInterceptorHelper
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new ApectInterceptorSelector()
                }).SingleInstance();
            #endregion
        }
    }
}
