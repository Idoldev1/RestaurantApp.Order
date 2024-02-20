using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Order.Domain.Entities;


public class Orders
{
    [Column("Order Id")]
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public string CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public OrderStatus OrderStatus { get; set; }
}