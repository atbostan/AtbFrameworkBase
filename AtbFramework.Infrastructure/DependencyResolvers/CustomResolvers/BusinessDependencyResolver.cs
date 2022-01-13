using AtbFramework.Application.Business;
using AtbFramework.Application.Interfaces.Business;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Infrastructure.Interfaces.DependencyResolver;
using AtbFramework.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AtbFramework.Infrastructure.DependencyResolvers.CustomResolvers
{
    public class BusinessDependencyResolver : ICustomResolverModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            serviceCollection.AddScoped(typeof(IBaseService<,,>), typeof(BaseService<,,>));
        }
    }
}
