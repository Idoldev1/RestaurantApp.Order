using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Order.Domain.Entities;


public class OrderItem
{
    [Key]
    public int FoodId { get; set; }
    public string FoodName { get; set; }
}