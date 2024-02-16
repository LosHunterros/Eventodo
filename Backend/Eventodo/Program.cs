using Eventodo.Infrastructure;
using Eventodo.Aplication.Repositorys;
using Eventodo.Aplication.Profiles.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EventodoDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("EventodoDBPosrgreSQL"));
    options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
});

builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IModulesRepository, ModulesRepository>();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(EventProfile)));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder
            .WithOrigins("http://localhost:7050")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddControllers(configure =>
{
    configure.CacheProfiles.Add("Any-20",
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.UseAllOfForInheritance();
    swaggerGenOptions.UseOneOfForPolymorphism();

    swaggerGenOptions.SelectSubTypesUsing(baseType =>
        typeof(Program).Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType))
    );
});

builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
//}
//else
//{
//   app.UseExceptionHandler();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.UseResponseCaching();

app.MapControllers();

app.Run();
