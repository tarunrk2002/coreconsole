using Microsoft.Extensions.Configuration;
using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace mmmmmcore
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            
            Console.WriteLine(builder.Build);
            Console.WriteLine(Directory.GetCreationTime(Directory.GetCurrentDirectory()));


            

            LoggerConfiguration logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console();

            Log.Logger = logger.CreateLogger();
            Log.Logger.Information("something started");



            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, service) =>
                {
                    service.AddScoped<IGreetingService, GreetingService>();
                })
                .UseSerilog()
                
                .Build();

            var svc = ActivatorUtilities.CreateInstance<IGreetingService>(host.Services);

           
            
        }

        public static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json",optional:false,reloadOnChange:true);
            builder.AddEnvironmentVariables();
            builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "production"}.json", optional: true);
            
        }

        public static void bc(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
        }
    }
}
