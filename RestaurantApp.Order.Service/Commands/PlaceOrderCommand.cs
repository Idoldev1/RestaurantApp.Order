using MediatR;
using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Service.Commands;

public class PlaceOrderCommand : IRequest<string>
{
    public string CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}