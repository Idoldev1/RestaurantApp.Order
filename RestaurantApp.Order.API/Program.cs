using NLog;
using RestaurantApp.Order.API.Services;
using RestaurantApp.Order.LoggerService.Extensions;
using RestaurantApp.Order.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.Setup().LoadConfiguration(log => {
    log.ForLogger().FilterMinLevel(NLog.LogLevel.Info).WriteToConsole();
    log.ForLogger().FilterMinLevel(NLog.LogLevel.Debug).WriteToFile(fileName: "./logs/${shortdate}_logfile.txt");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
        .WithMethods("POST", "GET")
        .AllowAnyHeader());
});

builder.Services.AddServiceDependencies(builder.Configuration);
builder.Services.AddLoggerDependencies();
builder.Services.AddHostedService<RabbitMqBackgroundServices>();

var app = builder.Build();

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
