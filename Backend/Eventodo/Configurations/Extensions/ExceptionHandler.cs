using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;

namespace Eventodo.Configurations.Extensions
{
    public static class ErrorHandlingExtensions
    {
        public static void ExceptionHandler(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                ILogger<Program> logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

                IExceptionHandlerFeature? exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
                Exception? exception = exceptionDetails?.Error;

                logger.LogError(
                    exception,
                    "Could not process a request on machine {Machine}. TraceId: {TraceId}",
                    Environment.MachineName,
                    Activity.Current?.Id);

                await Results.Problem(
                    title: "We made a mistake but we are working on it!",
                    statusCode: StatusCodes.Status500InternalServerError,
                    extensions: new Dictionary<string, object?>
                    {
                    {"traceId", Activity.Current?.Id}
                    }
                )
                .ExecuteAsync(context);
            });
        }
    }
}
