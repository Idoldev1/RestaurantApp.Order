using MassTransit;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Contracts.Messages;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Consumers;


public class OrderStartedConsumer : IConsumer<OrderStartedMessage>
{
    private readonly IOrderRepository _orderRepository;

    public OrderStartedConsumer(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Consume(ConsumeContext<OrderStartedMessage> context)
    {
        // Retrieve properties from the appropriate class
        var orderId = context.Message.OrderId;
        var customerId = context.Message.CustomerId;

        // Retrieve the order from the database
        var order = await _orderRepository.GetOrderByIdAsync(orderId);


        // Check if the response from the repository isn't null before proceeding with logic
        if (order != null)
        {
            order.OrderStatus = OrderStatus.Started;

            // You might include additional logic, such as sending notifications, updating UI, etc.

            // Save the updated order back to the database
            await _orderRepository.UpdateOrdersAsync(order);
        }
    }
}
