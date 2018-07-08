﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DomainModels;
using Api.Models;
using Api.Services.Automapper;
using Api.Services.Injector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
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
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                         builder => builder
                         .AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                    );
            });
            services.AddIdentity<AppIdentityUser, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>()
                    .AddDefaultTokenProviders();
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.RegisterServices();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors("AllowAllHeaders");
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
