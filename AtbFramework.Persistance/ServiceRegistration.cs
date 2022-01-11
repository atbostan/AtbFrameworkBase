using AtbFramework.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtbFramework.Persistance
{
    public static class ServiceRegistration 
    {
        public static void AddPersistanceServices(this IServiceCollection services , IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SQLConnection"].ToString(), o => o.MigrationsAssembly("AtbFramework.Persistance"));
            });


        }
    }
}
