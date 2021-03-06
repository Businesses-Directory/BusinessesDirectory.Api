using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BusinessesDirectoryApi.Services;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using BusinessesDirectoryApi.Repositories;
using Microsoft.Extensions.DependencyInjection;
using BusinessesDirectoryApi.Services.TypesServices;
using BusinessesDirectoryApi.Repositories.TypesRepositories;
using BusinessesDirectoryApi.Models.ContextModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessesDirectoryApi.Models.SeedModel;
using BusinessesDirectoryApi.ErrorHandling.Extensions;
using BusinessesDirectoryApi.ErrorHandling.CustomExceptionMiddleware;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using System.IO;

namespace BusinessesDirectoryApi
{
    public class Startup
    {
        private readonly string allowedDevelopmentOrigin = "AllowAngularCliOrigin";
        private readonly string allowedProductionOrigin = "AllowOrigin";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AngelR   ConnectionString: "SQLCONNSTR_BUSINESSESDIRECTORY": "Server=IVDL0122;Initial Catalog=BusinessesDirectory;User ID=sa;Password=12345678;"
            // Jos�R    ConnectionString: "SQLCONNSTR_BUSINESSESDIRECTORY": "Server=[computername];Initial Catalog=BusinessesDirectory;User ID=sa;Password=[password];"
            // GabrielA ConnectionString: "SQLCONNSTR_BUSINESSESDIRECTORY": "Server=[computername];Initial Catalog=BusinessesDirectory;User ID=sa;Password=[password];"
            // Azure ConnectionString: "SQLCONNSTR_BUSINESSESDIRECTORY": [Azure Connection String]
            var sqlServerConnectionString = Configuration.GetConnectionString("SQLCONNSTR_BUSINESSESDIRECTORY");
            if (sqlServerConnectionString == null)
            {
                throw new Exception("BUSINESSESDIRECTORY connection string is not set.");
            }
            services.AddDbContext<BusinessesDirectoryContext>(options =>
              options.UseSqlServer(sqlServerConnectionString));
            services.AddCors(options =>
            {
                options.AddPolicy(allowedDevelopmentOrigin,
                  policy => policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                );
                options.AddPolicy(allowedProductionOrigin,
                  policy => policy.WithOrigins("https://www.lockdowndirectory.com")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                );
            }
            );
            services.AddTransient<Seed>();
            services.AddAutoMapper();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IBusinessTypeService, BusinessTypeService>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<IBusinessTypeRepository, BusinessTypeRepository>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "BD_DistFiles";
            //});
            // Configure Custom Validation Error Handling
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ctx => ValidationErrorResult.GetValidationErrors(ctx);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {
            if (env.IsDevelopment())
            {
                seeder.SeedDb();
                app.UseDeveloperExceptionPage();
                app.UseCors(allowedDevelopmentOrigin);
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                //app.UseCors(allowedProductionOrigin);
                app.UseCors(allowedDevelopmentOrigin);
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseSpaStaticFiles();
            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "BD_DistFiles";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});

        }
    }
}
