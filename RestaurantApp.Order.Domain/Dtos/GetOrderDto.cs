using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Domain.Dtos;


public record GetOrderDto
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public OrderStatus OrderStatus { get; set; }
}