﻿using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Repository.Context;
using Services.IServices;
using Services.IServices.Identity;
using Services.Services;
using Services.Services.Identity;

namespace BaseWeb
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        private const string ConnectionString = "DefaultConnection";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionString));
            });

            services.AddTransient<ApplicationDbSeeder>();
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IJWTService, JWTService>();
            services.AddTransient<IRoutineService, RoutineService>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAny", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceCollection services)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI();

                var provider = services.BuildServiceProvider();

                var seed = provider.GetService<ApplicationDbSeeder>();

                seed.EnsureSeed().GetAwaiter().GetResult();
            }

            app.UseCors("AllowAny");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpsRedirection();
        }
    }
}
