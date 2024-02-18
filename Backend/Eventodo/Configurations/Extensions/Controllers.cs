using Eventodo.Configurations.Options;
using Microsoft.AspNetCore.Mvc;

namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions<CacheOptions>()
                .Bind(builder.Configuration.GetSection(CacheOptions.SectionName))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            builder.Services.AddControllers(options =>
            {
                options.CacheProfiles.Add("ResponseCache",
                    new CacheProfile
                    {
                        Location = ResponseCacheLocation.Any,
                        Duration = Convert.ToInt32(builder.Configuration[$"{CacheOptions.SectionName}:ResponseCacheDuration"])
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
