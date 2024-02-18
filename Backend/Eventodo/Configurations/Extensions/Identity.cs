using Eventodo.Core;
using Eventodo.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<EventodoDbContext>()
            .AddDefaultTokenProviders();

            return builder;
        }
    }
}
