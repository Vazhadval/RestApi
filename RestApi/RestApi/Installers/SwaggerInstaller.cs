﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RestApi.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                //new Info { Title = "Rest API", Version = "v1" }
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Rest API", Version = "v1" });

                x.ExampleFilters();

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer",new string[0] }
                };

                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {new OpenApiSecurityScheme
                    {
                        Reference=new OpenApiReference
                        {
                            Id="Bearer",
                            Type=ReferenceType.SecurityScheme
                        }
                    }
                    ,new List<string>() }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xlmPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xlmPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();


        }
    }
}
