using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Order.LoggerService.Implementations;
using RestaurantApp.Order.LoggerService.Interfaces;

namespace RestaurantApp.Order.LoggerService.Extensions;


public static class LoggerConfig
{
    public static void AddLoggerDependencies(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}