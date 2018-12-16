using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Rbyte.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args);

            host
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("connectionString.json");
                    config.AddJsonFile($"connectionString.{hostingContext.HostingEnvironment.EnvironmentName}.json");
                });
            host.UseStartup<Startup>();

            return host;
        }
    }
}
