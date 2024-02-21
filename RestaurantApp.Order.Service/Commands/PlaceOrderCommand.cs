using MediatR;
using RestaurantApp.Order.Domain.Dtos;
using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Commands;

public class PlaceOrderCommand : IRequest<PlaceOrderDto>
{
    public string CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}