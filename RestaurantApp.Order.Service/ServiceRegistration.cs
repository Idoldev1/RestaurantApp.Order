using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantApp.Order.Service.Consumers;
using RestaurantApp.Order.Service.Repositories.Implementation;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service;


public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configurations)
    {
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddMediatR(typeof(IServiceCollection).Assembly);

        services.AddMassTransit(x =>
        {
            x.AddConsumer<OrderStartedConsumer>();
            x.AddConsumer<OrderCompletedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(""), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        });

        services.AddMassTransitHostedService();


        return services;
    }
}