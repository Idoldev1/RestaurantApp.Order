using AutoMapper;
using MediatR;
using RestaurantApp.Order.Domain.Dtos;
using RestaurantApp.Order.Domain.Exceptions;
using RestaurantApp.Order.LoggerService.Interfaces;
using RestaurantApp.Order.Service.Repositories.Interfaces;

namespace RestaurantApp.Order.Service.Queries;


public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderDto>
{
    private IOrderRepository _orderRepository;
    private ILoggerManager _logger;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, ILoggerManager logger, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<GetOrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        
        var order = await _orderRepository.GetOrderByIdAsync(request.OrderId);
        if(order == null)
        {
            _logger.LogError("Requested Order details not found in the database");
            throw new OrderNotFoundException(request.OrderId);
        }

        var orders = _mapper.Map<GetOrderDto>(order);

        return orders;


    }
}