using MassTransit;
using RestaurantApp.Order.Service.Contracts.Messages;

namespace RestaurantApp.Order.Service.Consumers;


public class OrderCompletedConsumer : IConsumer<OrderCompletedMessage>
{
    public Task Consume(ConsumeContext<OrderCompletedMessage> context)
    {
        throw new NotImplementedException();
    }
}
