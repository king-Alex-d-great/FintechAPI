using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OnlineBankApi.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using System.IO;
using Microsoft.Extensions.Configuration;
using Contracts;
using Repositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineBankApi
{
    public class StartUp
    {
        private readonly IConfiguration configuration;

        public StartUp(IConfiguration configuration)
        {           
             LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSqlContext(configuration);
            services.AddControllers();
           
            services.ConfigureCORS(); 
            services.ConfigureIISIntegration();
            services.ConfigureILogger();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("policy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All,
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoint => endpoint.MapDefaultControllerRoute());
        }
    }
}
