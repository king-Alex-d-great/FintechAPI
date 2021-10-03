using Contracts;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Entities.Models;

namespace OnlineBankApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCORS (this IServiceCollection services)
        {
            services.AddCors(options =>

                options.AddPolicy("policy", builder =>
                {
                    builder.AllowCredentials()
                    .AllowAnyHeader().AllowAnyMethod();
                })
           );
        }

        public static void ConfigureIISIntegration(this IServiceCollection services) => services.Configure<IISOptions>(options => { }); //empty cause we are ok using the defaults
        public static void ConfigureILogger(this IServiceCollection services) => services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<OnlineBankApiContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("ApiConnection")));
    }
}
