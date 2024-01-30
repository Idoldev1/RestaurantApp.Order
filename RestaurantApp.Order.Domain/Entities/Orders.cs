using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Order.Domain.Entities;


public class Orders
{
    [Key]
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public string CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public OrderStatus OrderStatus { get; set; }
}