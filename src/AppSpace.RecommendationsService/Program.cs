using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AppSpace.RecommendationsService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureAppConfiguration(d =>
                new ConfigurationBuilder()
                .AddJsonFile("appSettings.json", true, true)
                .AddJsonFile("appSettings.Development.json", true, true)
                .AddUserSecrets(Assembly.GetExecutingAssembly()).Build())
            .UseSerilog((context, services, configuration) => configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext()
                .WriteTo.Console());
    }
}