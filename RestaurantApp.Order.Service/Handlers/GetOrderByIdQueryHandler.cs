using MediatR;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Domain.Exceptions;
using RestaurantApp.Order.LoggerService.Interfaces;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Queries;


public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Orders>
{
    private IOrderRepository _orderRepository;
    private ILoggerManager _logger;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, ILoggerManager logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<Orders> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {

        if (request == null)
        {
            _logger.LogError("Invalid OrderId inputed");
        }
        var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
        if(order == null)
        {
            _logger.LogError("Requested Order details not found in the database");
            throw new OrderNotFoundException(request.OrderId);
        }
        
        /*var orderDto = new Orders
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
        };*/
        return order;


    }
}