using AtbFramework.Bindings.Interfaces.DependencyResolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtbFramework.Application.CrossCuttingConcerns.Logging.Service;
using AtbFramework.Bindings.DependencyResolvers.CustomResolvers;
using AtbFramework.Bindings.Extensions;
using AtbFramework.Bindings.Mapping.Automap;
using AtbFramework.Persistance.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtbFramework.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //AutoMApperConfiguration
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AtbFramework.WebAPI", Version = "v1" });
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SQLConnection"].ToString(), o => o.MigrationsAssembly("AtbFramework.Persistance"));
            });


            services.AddDependencyResolvers(new ICustomResolverModule[] {
                new BusinessDependencyResolver()
            });

            services.AddTransient<FileLogger>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AtbFramework.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowOrigin");


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
