﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Data;
using RestApi.Services;

namespace RestApi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("LocalDbConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IPostService, PostService>();
            //services.AddSingleton<IPostService, CosmosPostService>();
        }
    }
}
