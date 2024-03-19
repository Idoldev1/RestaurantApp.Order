using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Domain.Dtos;


public record GetOrderDto
{
    public string OrderId { get; set; }
    public string CustomerId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public OrderStatus OrderStatus { get; set; }
}

public class OrderItemDto
{
    public int FoodId { get; set; }
    public string FoodName { get; set; }
    public int Quantity { get; set; }
}