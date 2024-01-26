using MassTransit;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Contracts.Messages;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Consumers;


public class OrderCompletedConsumer : IConsumer<OrderCompletedMessage>
{
    private readonly IOrderRepository _orderRepository;

    public OrderCompletedConsumer(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Consume(ConsumeContext<OrderCompletedMessage> context)
    {
        var orderId = context.Message.OrderId;
        var customerId = context.Message.CustomerId;

        // Retrieve the order from the database
            var order = await _orderRepository.GetOrderByIdAsync(orderId);

            if (order != null)
            {
                // Update the order status to "Completed"
                order.OrderStatus = OrderStatus.Completed;

                // You might include additional logic, such as sending notifications, updating UI, etc.

                // Save the updated order back to the database
                await _orderRepository.UpdateOrderAsync(order);
    }
}
