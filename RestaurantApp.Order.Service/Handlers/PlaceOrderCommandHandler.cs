using AutoMapper;
using MassTransit;
using MediatR;
using RestaurantApp.Order.Domain.Dtos;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.LoggerService.Interfaces;
using RestaurantApp.Order.Service.Commands;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Handlers;


public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, GetOrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBus _publish;
    private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;

    public PlaceOrderCommandHandler(IOrderRepository orderRepository, IBus publish, IMapper mapper, ILoggerManager logger)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _publish = publish ?? throw new ArgumentNullException(nameof(publish));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<GetOrderDto> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {

        try
        {
            //Create a new Order
            var order = new Orders
            {
                CustomerId = request.CustomerId,
                OrderStatus = OrderStatus.Queued,
                // Mapping the list of OrderItemDto to the list of OrderItem manually
                OrderItems = request.OrderItems.Select(dto => new OrderItem
                {
                    FoodId = dto.FoodId,
                    FoodName = dto.FoodName,
                    Quantity = dto.Quantity,
                    // Set other properties as required
                }).ToList()
            };

            // Save the order
            _orderRepository.PlaceOrderAsync(order);

            // You might include additional logic, such as sending email and SMS notifications

            // Map the saved order to GetOrderDto manually
            var newOrder = new GetOrderDto
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                OrderItems = order.OrderItems.Select(item => new OrderItemDto
                {
                    FoodId = item.FoodId,
                    FoodName = item.FoodName,
                    Quantity = item.Quantity,
                    // Set other properties as required
                }).ToList(),
                OrderStatus = order.OrderStatus
                // Map other properties as required
            };

            // Publish the order (if needed)
            // await _publish.Publish(newOrder);

            return newOrder;
        }

        catch (Exception ex)
        {
            _logger.LogError($"{ex}");

            throw;
        }

    }
}