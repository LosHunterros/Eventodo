using Eventodo.Infrastructure;
using Eventodo.Aplication.Repositorys;
using Eventodo.Aplication.Profiles.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Eventodo.Configurations.Extensions;

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

builder.AddCors();

builder.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.AddSwagger();

builder.AddIdentity();

builder.AddJWT();

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
