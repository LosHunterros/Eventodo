using Eventodo.Configurations.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddJWT(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions<JWTOptions>()
                .Bind(builder.Configuration.GetSection(JWTOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            builder.Services.AddAuthentication()
                .AddJwtBearer((options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration[$"{JWTOptions.SectionName}:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = builder.Configuration[$"{JWTOptions.SectionName}:Audience"],

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[$"{JWTOptions.SectionName}:SigningKey"]!))
                    };
                }));

            builder.Services.AddAuthorization(options =>
            {
                AuthorizationPolicyBuilder defaultAuthorizationPolicyBuilder = new (JwtBearerDefaults.AuthenticationScheme);
                defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();

                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });
            });

            return builder;
        }
    }
}
