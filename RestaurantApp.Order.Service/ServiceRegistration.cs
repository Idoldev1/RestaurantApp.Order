using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Order.Service.Repositories.Implementation;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service;


public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddMediatR(typeof(IServiceCollection).Assembly);

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("myuser");
                    h.Password("mypass");
                });
            });
        });


        return services;
    }
}