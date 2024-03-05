using MediatR;
using RestaurantApp.Order.Domain.Dtos;
using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Commands;

public class PlaceOrderCommand : IRequest<GetOrderDto>
{
    public string CustomerId { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}