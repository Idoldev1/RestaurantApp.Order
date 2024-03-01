using MediatR;
using RestaurantApp.Order.Domain.Dtos;
using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Queries;


public class GetOrderByIdQuery : IRequest<GetOrderDto>
{
    public string OrderId { get; set; }
}