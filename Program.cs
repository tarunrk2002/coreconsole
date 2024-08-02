using Microsoft.Extensions.Configuration;

namespace mmmmmcore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

        }

        public static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json",optional:false,reloadOnChange:true);
            builder.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENR") ?? "production"}.json",optional: true);
            builder.AddEnvironmentVariables();
        }

    }
}
