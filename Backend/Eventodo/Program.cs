using Eventodo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EventodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventodoDb"));
    options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
});

builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IModulesRepository, ModulesRepository>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // required to prevent "Self referencing loop detected" error
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
