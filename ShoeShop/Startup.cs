using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoeShop.Businness.Abstract;
using ShoeShop.Businness.Concrete;
using ShoeShop.Businness.MapperProfile;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.DataAccess.Concrete.Repository;

namespace ShoeShop
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
            services.AddControllersWithViews();
            services.AddScoped<IProductRepository,EfProductRepository>();
            services.AddScoped<IProductService,ProductManager>();
            services.AddScoped<ICategoryRepository,EfCategoryRepository>();
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddScoped<IBrandService,BrandManager>();
            services.AddScoped<IBrandRepository,EfBrandRepository>();
            services.AddScoped<IColorRepository,EfColorRepository>();
            services.AddScoped<IColorService,ColorManager>();
            services.AddScoped<IGenderRepository,EfGenderRpository>();
            services.AddScoped<IGenderService,GenderManager>();
            services.AddScoped<IStockRepository, EfStockRepository>();
            services.AddScoped<IStockService, StockManager>();
            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<ShoeShopDbContext>(opt => opt.UseNpgsql(connectionString));
            services.AddAutoMapper(typeof(MapProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Urunler/Sayfa{page}",
                    defaults: new { controller = "Products", action = "Show", page = 1 });

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{catName}/Sayfa{page}",
                    defaults: new { controller = "Home", action = "Index", page = 1 });
                
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Detaylar/{productID}",
                    defaults: new { controller = "Products", action = "Details" });

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{catName}",
                    defaults: new { controller = "Home", action = "Index", page = 1 });


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Sayfa{page}",
                    defaults: new { controller = "Home", action = "Index", page = 1 });

            });
        }
    }
}
