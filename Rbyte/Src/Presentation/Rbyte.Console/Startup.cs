using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rbyte.Persistance;

namespace Rbyte.ConsoleApp
{
    public static class Startup
    {
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();
            // Add DbContext using MySQL Server Provider
            services.AddDbContext<RbyteContext>(options =>
                options.UseMySQL("server=localhost;database=rByte;user=root;password=admin"));
        }

    }
}
