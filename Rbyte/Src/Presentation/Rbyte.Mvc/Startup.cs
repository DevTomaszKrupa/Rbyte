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
using Rbyte.Application.Product.Read;
using Rbyte.Application.Product.Update;
using Rbyte.Application.Discount.Create;
using Rbyte.Application.Discount.Read;
using Rbyte.Application.Discount.Update;
using Rbyte.Application.Store.Create;
using Rbyte.Application.Store.Read;
using Rbyte.Application.Store.Update;
using Rbyte.Application.Tax;
using Rbyte.Application.Store.Add;
using Rbyte.Application.Store.Details;
using Rbyte.Application.Tax.Create;
using Rbyte.Application.Tax.Read;
using Rbyte.Application.Tax.Update;

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
            services.AddTransient<IValidator<ReadProductModel>, ReadProductModelValidator>();
            services.AddTransient<IValidator<UpdateProductModel>, UpdateProductModelValidator>();

            services.AddTransient<IValidator<CreateDiscountModel>, CreateDiscountModelValidator>();
            services.AddTransient<IValidator<ReadDiscountModel>, ReadDiscountModelValidator>();
            services.AddTransient<IValidator<UpdateDiscountModel>, UpdateDiscountModelValidator>();

            services.AddTransient<IValidator<CreateStoreModel>, CreateStoreModelValidator>();
            services.AddTransient<IValidator<ReadStoreModel>, ReadStoreModelValidator>();
            services.AddTransient<IValidator<UpdateStoreModel>, UpdateStoreModelValidator>();
            services.AddTransient<IValidator<AddStoreProductModel>, AddStoreProductModelValidator>();
            services.AddTransient<IValidator<DetailsStoreModel>, DetailsStoreModelValidator>();

            services.AddTransient<IValidator<CreateTaxModel>, CreateTaxModelValidator>();
            services.AddTransient<IValidator<ReadTaxModel>, ReadTaxModelValidator>();
            services.AddTransient<IValidator<UpdateTaxModel>, UpdateTaxModelValidator>();

            // services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ITaxService, TaxService>();
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
                case "MSSQL":
                    connectionString = _configuration.GetSection("MSSQLConnectionString").Value;
                    services.AddDbContext<MSSqlRbyteContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });
                    services.AddScoped<RbyteContext, MSSqlRbyteContext>();
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
