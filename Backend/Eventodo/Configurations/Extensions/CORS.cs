﻿using Eventodo.Configurations.Options;

namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions<CorsOptions>()
                .Bind(builder.Configuration.GetSection(CorsOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>
                {
                    var origins = new List<string>();

                    builder.Configuration.Bind($"{CorsOptions.SectionName}:Origins", origins);

                    policyBuilder
                        .WithOrigins(origins.ToArray())
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return builder;
        }
    }
}
