using AtbFramework.Application.Business;
using AtbFramework.Application.Interfaces.Business;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Infrastructure.Interceptors;
using AtbFramework.Persistance.Repositories;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Bindings.DependencyResolvers.Autofac
{
    /// <summary>
    /// This class use for DI with the help of Autofac
    /// </summary>
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
