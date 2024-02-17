namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilerExtension
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(swaggerGenOptions =>
            {
                swaggerGenOptions.UseAllOfForInheritance();
                swaggerGenOptions.UseOneOfForPolymorphism();

                swaggerGenOptions.SelectSubTypesUsing(baseType =>
                    typeof(Program).Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType))
                );
            });
            return builder;
        }
    }
}
