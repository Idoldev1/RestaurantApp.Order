using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using RestaurantApp.Order.API.Extension;
using RestaurantApp.Order.Data.DataAccess;
using RestaurantApp.Order.LoggerService.Extensions;
using RestaurantApp.Order.LoggerService.Interfaces;
using RestaurantApp.Order.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddDbContext<OrderDb>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("OrderDbConnection"));
});

builder.Services.AddServiceDependencies(builder.Configuration);
builder.Services.AddScoped<OrderDb>();
builder.Services.AddLoggerDependencies();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
//builder.Services.AddHostedService<RabbitMqBackgroundServices>();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
app.UseHsts();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
