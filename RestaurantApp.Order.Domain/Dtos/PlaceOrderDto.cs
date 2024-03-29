using System.ComponentModel.DataAnnotations;
using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Domain.Dtos;


public record PlaceOrderDto
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    
    [Required(ErrorMessage = "Customer ID is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for ID is 30 characters.")]
    public string CustomerId { get; init; }
    public ICollection<OrderItem> OrderItems { get; init; }
    public OrderStatus OrderStatus { get; init; }
}