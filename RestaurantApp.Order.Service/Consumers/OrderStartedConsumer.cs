using MassTransit;
using RestaurantApp.Order.Service.Contracts.Messages;

namespace RestaurantApp.Order.Service.Consumers;


public class OrderStartedConsumer : IConsumer<OrderStartedMessage>
{
    public Task Consume(ConsumeContext<OrderStartedMessage> context)
    {
        throw new NotImplementedException();
    }
}
