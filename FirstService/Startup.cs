﻿using FirstService.Implementations;
using FirstService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack.Redis;
using System.Net.Http;

namespace FirstService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RedisOptions>(Configuration.GetSection("redis"));

            string redisConnection = Configuration["redis:name"];
            services.AddScoped(provider => new RedisManagerPool(redisConnection).GetClient());

            services.AddSingleton<HttpClient>();
            services.AddScoped<IRedisRepository, RedisRepository>();
            services.AddScoped<IFirstBusiness, FirstBusiness>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
