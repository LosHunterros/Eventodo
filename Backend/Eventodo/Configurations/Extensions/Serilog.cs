using Serilog;

namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilderExtension
    {
        public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, services, options) =>
            {
                options.ReadFrom.Configuration(context.Configuration);
                options.ReadFrom.Services(services);
            }, preserveStaticLogger: true);

            return builder;
        }
    }
}
