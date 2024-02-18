using Microsoft.AspNetCore.Mvc;

namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Any-20",
                    new CacheProfile
                    {
                        Location = ResponseCacheLocation.Any,
                        Duration = 20
                    });
            }).AddNewtonsoftJson(options =>
            {
                // required to prevent "Self referencing loop detected" error
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            return builder;
        }
    }
}
