using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtbFramework.Application.Business;
using AtbFramework.Application.Interfaces.Repository;
using AtbFramework.Bindings.Interfaces.DependencyResolver;
using Microsoft.Extensions.DependencyInjection;
using AtbFramework.Persistance.Repositories;
using AtbFramework.Application.Interfaces.Business;

namespace AtbFramework.Bindings.DependencyResolvers.CustomResolvers
{
    public class BusinessDependencyResolver : ICustomResolverModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            //serviceCollection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            //serviceCollection.AddScoped(typeof(IBaseService<,,>), typeof(BaseService<,,>));
        }
    }
}
