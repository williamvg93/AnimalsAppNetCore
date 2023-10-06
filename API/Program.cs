using System.Reflection;
using API.Extensions;
using AspNetCoreRateLimit;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

/* Extension necesaria para limitar número de peticiones */
builder.Services.ConfigureRatelimiting();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());


/* Agregar la extension AddApplicationServices de AddApplicationServices */
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnimalsContext>(options =>
{
    string connectionStrings = builder.Configuration.GetConnectionString("MysqlConec");
    options.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/* Implementación de las Cors */
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

/* Implementación del RateLimit */
app.UseIpRateLimiting();

app.UseAuthorization();

app.MapControllers();

app.Run();
