using MassTransit;
using MediatR;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Commands;
using RestaurantApp.Order.Service.Contracts.Messages;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Handlers;


public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, string>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBus _publish;

    public PlaceOrderCommandHandler(IOrderRepository orderRepository, IBus publish)
    {
        _orderRepository = orderRepository;
        _publish = publish;
    }

    public async Task<string> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Orders
        {
            CustomerId = request.CustomerId,
            OrderItems = request.OrderItems.Select(item => new OrderItem
            {
                FoodId = item.FoodId,
                FoodName = item.FoodName,
                // Map other properties...
            }).ToList(),
            OrderStatus = OrderStatus.Queued,
            //Set other properties as required
        };

        var orderId = await _orderRepository.PlaceOrderAsync(order);

        // You might include additional logic, such as sending email and SMS notifications


        await _publish.Publish(order, cancellationToken);

        return orderId;

    }
}