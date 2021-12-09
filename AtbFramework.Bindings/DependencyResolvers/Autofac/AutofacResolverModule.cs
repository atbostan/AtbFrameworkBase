using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Module = Autofac.Module;

namespace AtbFramework.Bindings.DependencyResolvers.Autofac
{
    public class AutofacResolverModule : Module
    {
        public AutofacResolverModule()
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            #region AutofacInterceptorHelper
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new ApectInterceptorSelector()
                }).SingleInstance().InstancePerDependency();
            #endregion
        }
    }
}
