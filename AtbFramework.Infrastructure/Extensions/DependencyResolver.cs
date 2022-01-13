using AtbFramework.Application.DependencyResolvers;
using AtbFramework.Infrastructure.Interfaces.DependencyResolver;
using Microsoft.Extensions.DependencyInjection;

namespace AtbFramework.Infrastructure.Extensions
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
