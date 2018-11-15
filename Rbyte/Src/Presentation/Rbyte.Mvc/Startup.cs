using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rbyte.Application.Product.Commands.CreateProduct;
using Rbyte.Application.Product.Commands.DeleteProduct;
using Rbyte.Application.Product.Commands.UpdateProduct;
using Rbyte.Application.Product.Queries.GetProductDetails;
using Rbyte.Application.Product.Queries.GetProductsList;
using Rbyte.Persistance;

namespace Rbyte.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<RbyteContext>(options => 
                    options.UseMySQL("server=localhost;database=rByte;user=root;password=admin"));

            services.AddScoped<ICreateProductCommandHandler, CreateProductCommandHandler>();
            services.AddScoped<IDeleteProductCommandHandler, DeleteProductCommandHandler>();
            services.AddScoped<IUpdateProductCommandHandler, UpdateProductCommandHandler>();
            services.AddScoped<IGetProductDetailsQueryHandler, GetProductDetailsQueryHandler>();
            services.AddScoped<IGetProductsListQueryHandler, GetProductsListQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
