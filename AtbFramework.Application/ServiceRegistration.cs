using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AtbFramework.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
  
        }
    }
}
