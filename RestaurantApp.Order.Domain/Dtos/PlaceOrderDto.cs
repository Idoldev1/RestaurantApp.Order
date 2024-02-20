using System.ComponentModel.DataAnnotations;
using RestaurantApp.Order.Domain.Entities;

namespace RestaurantApp.Order.Domain.Dtos;


public record PlaceOrderDto
{
    [Required(ErrorMessage = "Customer ID is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum length for ID is 30 characters.")]
    public string CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public OrderStatus OrderStatus { get; set; }
}