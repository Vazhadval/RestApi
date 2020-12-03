﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestApi.Authorization;
using RestApi.Filters;
using RestApi.Options;
using RestApi.Services;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddScoped<IIdentityService, IdentityService>();

            services
                 .AddMvc(options =>
                 {
                     options.EnableEndpointRouting = false;
                     options.Filters.Add<ValidationFilter>();
                 })
                 .AddFluentValidation(mvcConfiguration => mvcConfiguration.RegisterValidatorsFromAssemblyContaining<Startup>())
                 .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(x =>
               {
                   x.SaveToken = true;
                   x.TokenValidationParameters = tokenValidationParameters;
               });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustWorkForMyCompany", policy =>
                {
                    policy.AddRequirements(new WorksForCompanyRequirement("vazha.com"));
                });
            });

            services.AddSingleton<IAuthorizationHandler, WorksForCompanyHandler>();


        }
    }
}
