using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SaleAppExample.Data;
using SaleAppExample.Data.DbContext;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SaleAppExample;

public static class Program
{
    private static IConfigurationRoot _conf;
    public static void Main(string[] args)
    {
        var buildedHost = CreateHostBuilder(args);
            var b = buildedHost.Build();
        InitDb(b, _conf);
        b.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration((builderContext, config) =>
            {
                IHostEnvironment env = builderContext.HostingEnvironment;

                _conf = config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true).Build();
            });


    private static void InitDb(IHost host, IConfigurationRoot conf)
    {
        using (var scope = host.Services.CreateScope())
        {
            IServiceProvider services = scope.ServiceProvider;
            
                var context = new AppDbContextFactory(conf, services)
                    .CreateDbContext(new string[] {""});
                // AppDbInitializer.Initialize(context, conf);}
  
        }
    }
}