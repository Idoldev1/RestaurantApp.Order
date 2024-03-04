using AutoMapper;
using MassTransit;
using MediatR;
using RestaurantApp.Order.Domain.Dtos;
using RestaurantApp.Order.Domain.Entities;
using RestaurantApp.Order.Service.Commands;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Handlers;


public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, GetOrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBus _publish;
    private readonly IMapper _mapper;

    public PlaceOrderCommandHandler(IOrderRepository orderRepository, IBus publish, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _publish = publish;
        _mapper = mapper;
    }

    public async Task<GetOrderDto> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
    {

        //Create a new Order
        var order = new Orders();
        /*{
            CustomerId = request.CustomerId,
            OrderItems = request.OrderItems.Select(item => new OrderItem
            {
                FoodId = item.FoodId,
                FoodName = item.FoodName,
                // Map other properties...
            }).ToList(),
            OrderStatus = OrderStatus.Queued,
            //Set other properties as required
        };*/

        _orderRepository.PlaceOrderAsync(order);

        // You might include additional logic, such as sending email and SMS notifications

        var newOrder = _mapper.Map<GetOrderDto>(order);
        
        await _publish.Publish(newOrder);

        return newOrder;

    }
}