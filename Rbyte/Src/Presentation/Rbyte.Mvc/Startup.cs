using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rbyte.Application.Category;
using Rbyte.Application.Discount;
using Rbyte.Application.Product.Create;
using Rbyte.Application.Store;
using Rbyte.Persistance;
using Rbyte.Persistance.MySql;
using FluentValidation.AspNetCore;
using Rbyte.Persistance.PostgreSql;
using FluentValidation;
using Rbyte.Application.Category.Create;
using Rbyte.Application.Category.Read;
using Rbyte.Application.Category.Update;

namespace Rbyte.Mvc
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


        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()                
                .AddFluentValidation();

            ConfigureDatabaseConnection(services);

            // validators
            services.AddTransient<IValidator<CreateCategoryModel>, CreateCategoryModelValidator>();
            services.AddTransient<IValidator<ReadCategoryModel>, ReadCategoryModelValidator>();
            services.AddTransient<IValidator<UpdateCategoryModel>, UpdateCategoryModelValidator>();

            services.AddTransient<IValidator<CreateProductModel>, CreateProductModelValidator>();

            // services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IStoreService, StoreService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
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
                case "MSSQL":   // TODO
                    connectionString = _configuration.GetSection("MSSQLConnectionString").Value;
                    //services.AddDbContext<MSSqlRbyteContext>(options =>
                    //{
                    //    options.UseSqlServer(connectionString);
                    //});
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
