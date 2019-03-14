using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace QuartzMultipleScheduler.NetCore
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine($"Application is started. {DateTime.Now:dd.MM.yyyy h:mm:ss}");
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            IWebHost hostBuilder = new WebHostBuilder()
                .UseConfiguration(Configuration)
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            hostBuilder.Run();
        }
    }
}