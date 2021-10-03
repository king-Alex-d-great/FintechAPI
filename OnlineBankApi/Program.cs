using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace OnlineBankApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder ()
        {           
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webbuilder =>
                webbuilder.UseStartup<StartUp>());
        }


    }
}
