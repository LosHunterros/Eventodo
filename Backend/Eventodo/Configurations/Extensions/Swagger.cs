namespace Eventodo.Configurations.Extensions
{
    public static partial class WebApplicationBuilerExtension
    {
        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.UseAllOfForInheritance();
                options.UseOneOfForPolymorphism();

                options.SelectSubTypesUsing(baseType =>
                    typeof(Program).Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType))
                );
            });
            return builder;
        }
    }
}
