using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ShoeShop.Businness.Abstract;
using ShoeShop.Businness.Concrete;
using ShoeShop.Businness.MapperProfile;
using ShoeShop.DataAccess.Abstract;
using ShoeShop.DataAccess.Concrete.Repository;

namespace ShoeShop.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoeShop.API", Version = "v1" });
            });
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandRepository, EfBrandRepository>();
            services.AddScoped<IColorRepository, EfColorRepository>();
            services.AddScoped<IColorService, ColorManager>();
            services.AddScoped<IGenderRepository, EfGenderRpository>();
            services.AddScoped<IGenderService, GenderManager>();
            services.AddScoped<IStockRepository, EfStockRepository>();
            services.AddScoped<IStockService, StockManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IFavoriteRepository, EfFavoriteRepository>();
            services.AddScoped<IFavoriteService, FavoriteManager>();
            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<ShoeShopDbContext>(opt => opt.UseNpgsql(connectionString));
            services.AddAutoMapper(typeof(MapProfile));
            services.AddCors(opt => opt.AddPolicy("Allow", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ShoeShop-secret-info"));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateActor = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = "turkcell.bootcamp",
                        ValidAudience = "turkcell.bootcamp",
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key
                    };
                });
            services.AddMemoryCache();
            services.AddResponseCaching();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine(context.Request.Method);
            //    var isJsonContent = context.Request.HasJsonContentType();
            //    Console.WriteLine(isJsonContent);
            //    if (isJsonContent)
            //    {
            //        object body = await context.Request.ReadFromJsonAsync<object>();
            //        dynamic type = JsonConvert.DeserializeObject<dynamic>(body.ToString());
            //        Console.WriteLine(type.name);
            //    }
            //    await next.Invoke();
            //});


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoeShop.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseRouting();

            app.UseCors("Allow");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
