using MediatR;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Queries;


public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Orders>
{
    private IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Orders> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        throw new Exception("");

        if (!string.IsNullOrWhiteSpace(request.OrderId))
        {
            var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
            var orderDto = new Orders
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    FoodId = item.FoodId,
                    FoodName = item.FoodName,
                    // Map other properties...
                }).ToList(),
                OrderStatus = order.OrderStatus,
                // Map other properties...
            };
            return orderDto;
        }
        else
        {
            throw new Exception($"Requested details for Order {request.OrderId} not found");
        }
    }
}