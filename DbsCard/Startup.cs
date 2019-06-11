using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using DbsCard.Models;
using AutoMapper;
using DbsCard.Services.AutoMapper;
using DbsCard.BusinessComponents;
using DbsCard.BusinessComponents.Contracts;
using Newtonsoft.Json;

namespace DbsCard
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
            var connection = @"Server=(localdb)\mssqllocaldb;Database=DbsCard;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<AppDbContext>
               (options => options.UseSqlServer(connection));

            services.AddCors(options =>
            {
                options.AddPolicy("myAllowOriginOrs",
                builder =>
                {
                    builder.WithOrigins("http://localhost:8080");
                });
            });
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ICardBusiness, CardBusiness>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();

            }
            app.UseCors("myAllowOriginOrs");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseHttpsRedirection();

            JsonConvert.DefaultSettings = () => DbsCard.Converters.Converter.Settings;
        }
    }
}
