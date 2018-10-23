using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenTracing.Contrib.NetCore;
using Microsoft.Extensions.DependencyInjection;

namespace netcore_webapi_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services => {
                    if (String.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("LS_KEY"))) {
                        services.AddJaeger();
                    } else {
                        services.AddLightStep();
                    }
                    services.AddOpenTracing();
                });
                
    }
}
