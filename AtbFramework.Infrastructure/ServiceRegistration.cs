using AtbFramework.Infrastructure.Logging;
using AtbFramework.Infrastructure.Mapping.Automap;
using AtbFramework.Infrastructure.Validation;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AtbFramework.Infrastructure.DependencyResolvers.CustomResolvers;
using AtbFramework.Infrastructure.Extensions;
using AtbFramework.Infrastructure.Interfaces.DependencyResolver;

namespace AtbFramework.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddDependencyResolvers(new ICustomResolverModule[] {
                new BusinessDependencyResolver()
            });

            //AutoMApperConfiguration
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(assembly);

        }
    }
}
