using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rbyte.Application.Product.Create;
using Rbyte.Persistance;
using Rbyte.Persistance.MySql;
using Rbyte.Persistance.PostgreSql;

namespace Rbyte.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration,
                       IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabaseConnection(services);
            services.AddScoped<IProductService, ProductService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(o => o.AddPolicy("RbytePolicy", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("RbytePolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureDatabaseConnection(IServiceCollection services)
        {
            var connectionString = string.Empty;
            var databaseConfigType = _configuration.GetSection("Database").Value;
            switch (databaseConfigType)
            {
                case "MySql":
                    connectionString = _configuration.GetSection("MySqlConnectionString").Value;
                    services.AddDbContext<MySqlRbyteContext>(options =>
                    {
                        options.UseMySQL(connectionString);
                    });
                    services.AddScoped<RbyteContext, MySqlRbyteContext>();
                    break;
                case "MSSql":
                    connectionString = _configuration.GetSection("MSSqlConnectionString").Value;
                    services.AddDbContext<MSSqlRbyteContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });
                    services.AddScoped<RbyteContext, PostgreSqlRbyteContext>();
                    break;
                case "PostgreSql":
                    connectionString = _configuration.GetSection("PostgreSqlConnectionString").Value;
                    services.AddDbContext<PostgreSqlRbyteContext>(options =>
                    {
                        options.UseNpgsql(connectionString);
                    });
                    services.AddScoped<RbyteContext, PostgreSqlRbyteContext>();
                    break;
            }
        }
    }
}
