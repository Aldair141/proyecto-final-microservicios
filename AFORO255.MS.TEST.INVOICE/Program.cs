using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace AFORO255.MS.TEST.INVOICE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((host, builder)=>
                    {
                        IWebHostEnvironment env = host.HostingEnvironment;
                        builder.AddConfigServer(env.EnvironmentName);
                    });

                    webBuilder.UseStartup<Startup>();
                });
    }
}
