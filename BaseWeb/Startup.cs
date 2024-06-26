﻿using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

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

            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<ApplicationDbSeeder>();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
        }
    }
}
