using AtbFramework.Infrastructure.Mapping.Automap;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AtbFramework.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            //AutoMApperConfiguration
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
