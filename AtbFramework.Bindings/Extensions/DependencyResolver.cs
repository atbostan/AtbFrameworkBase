using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.DependencyResolvers;
using AtbFramework.Bindings.Interfaces.DependencyResolver;
using Microsoft.Extensions.DependencyInjection;

namespace AtbFramework.Bindings.Extensions
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICustomResolverModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);

        }
    }
}
